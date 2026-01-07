using FantasyHOF.Application.Enums;
using FantasyHOF.Application.QueryTypes.Records;
using FantasyHOF.Domain.Types.Views;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueSingleRecordDetailsQuery(int LeagueId, RecordType RecordType) : IRequest<List<RecordDetails>>
    {
        public sealed class GetLeagueSingleRecordDetailsQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetLeagueSingleRecordDetailsQuery, List<RecordDetails>>
        {
            public Task<List<RecordDetails>> Handle(GetLeagueSingleRecordDetailsQuery request, CancellationToken cancellationToken)
            {
                RecordCategory recordCategory = request.RecordType.GetMetadata().Category;

                switch (recordCategory)
                {
                    case RecordCategory.League:
                        return LoadLeagueRecordDetail(request.LeagueId, request.RecordType);
                    default:
                        return Task.FromResult<List<RecordDetails>>([]);
                }
            }

            private async Task<List<RecordDetails>> LoadLeagueRecordDetail(int leagueId, RecordType recordType)
            {
                RecordQuerySpecification<LeagueMemberAggregatedStats> querySpec = LeagueRecordSpecs.Specs[recordType];
                
                IQueryable<LeagueMemberAggregatedStats> baseQuery = database.LeagueMemberAggregatedStats
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.Member);

                List<LeagueMemberAggregatedStats> materializedStats = await SortQuery(baseQuery, querySpec)
                    .ToListAsync();

                return materializedStats
                    .Select((stat, i) => new RecordDetails
                    {
                        Member = stat.Member,
                        Value = querySpec.MetricSelector.Compile()(stat),
                        Rank = i + 1
                    })
                    .ToList();
            }

            private IQueryable<TEntity> SortQuery<TEntity>(IQueryable<TEntity> baseQuery, RecordQuerySpecification<TEntity> querySpec)
            {
                return querySpec.Descending ?
                    baseQuery.OrderByDescending(querySpec.MetricSelector) :
                    baseQuery.OrderBy(querySpec.MetricSelector);
            }
        }
    }

    public sealed record RecordQuerySpecification<TEntity>(
        Expression<Func<TEntity, decimal>> MetricSelector,
        bool Descending
    );

    public static class LeagueRecordSpecs
    {
        public static readonly IReadOnlyDictionary<RecordType, RecordQuerySpecification<LeagueMemberAggregatedStats>> Specs =
            new Dictionary<RecordType, RecordQuerySpecification<LeagueMemberAggregatedStats>>
            {
                [RecordType.MostPointsLeagueHistory] =
                    new(r => r.PointsFor, Descending: true),

                [RecordType.LeastPointsAllowedLeagueHistory] =
                    new(r => r.PointsAgainst, Descending: false),
            };
    }
}
