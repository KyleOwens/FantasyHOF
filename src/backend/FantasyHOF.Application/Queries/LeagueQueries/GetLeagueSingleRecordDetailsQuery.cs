using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Registries;
using FantasyHOF.Application.Types.Queries.Records;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueSingleRecordDetailsQuery(int LeagueId, RecordTypeId RecordType) : IRequest<List<RecordDetails>>
    {
        public sealed class GetLeagueSingleRecordDetailsQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetLeagueSingleRecordDetailsQuery, List<RecordDetails>>
        {
            public Task<List<RecordDetails>> Handle(GetLeagueSingleRecordDetailsQuery request, CancellationToken cancellationToken)
            {
                RecordCategoryId recordCategory = request.RecordType.GetMetadata().Category;

                switch (recordCategory)
                {
                    case RecordCategoryId.League:
                        return LoadLeagueRecordDetail(request.LeagueId, request.RecordType);
                    case RecordCategoryId.Season:
                        return LoadSeasonalRecordDetails(request.LeagueId, request.RecordType);
                    case RecordCategoryId.Week:
                        return LoadWeeklyRecordDetails(request.LeagueId, request.RecordType);
                    case RecordCategoryId.Player:
                        return LoadPlayerRecordDetails(request.LeagueId, request.RecordType);
                    default:
                        return Task.FromResult<List<RecordDetails>>([]);
                }
            }

            private async Task<List<RecordDetails>> LoadLeagueRecordDetail(int leagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<LeagueMemberAggregatedStats> projector = new(recordTypeId);

                IQueryable<LeagueMemberAggregatedStats> baseQuery = database.LeagueMemberAggregatedStats
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                List<LeagueMemberAggregatedStats> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                return materializedStats
                    .Select((stat, i) => new LeagueRecordDetails(i, new(recordTypeId), projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordDetails>()
                    .ToList();
            }

            private async Task<List<RecordDetails>> LoadSeasonalRecordDetails(int LeagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<LeagueSeasonMemberAggregatedStats> projector = new(recordTypeId);

                IQueryable<LeagueSeasonMemberAggregatedStats> baseQuery = database.LeagueSeasonMemberAggregatedStats
                    .Where(stats => stats.LeagueId == LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                List<LeagueSeasonMemberAggregatedStats> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                return materializedStats
                    .Select((stat, i) => new SeasonalRecordDetails(stat.Year, i, new(recordTypeId), projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordDetails>()
                    .ToList();
            }

            private async Task<List<RecordDetails>> LoadWeeklyRecordDetails(int LeagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<WeeklyAggregationData> projector = new(recordTypeId);

                IQueryable<WeeklyAggregationData> baseQuery = database.WeeklyAggregationData
                    .Where(stats => stats.LeagueId == LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                List<WeeklyAggregationData> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                return materializedStats
                    .Select((stat, i) => new WeeklyRecordDetails(stat.Year, stat.Week, i, new(recordTypeId), projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordDetails>()
                    .ToList();
            }

            private async Task<List<RecordDetails>> LoadPlayerRecordDetails(int LeagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<PlayerAggregationData> projector = new(recordTypeId);

                IQueryable<PlayerAggregationData> baseQuery = database.PlayerAggregationData
                    .Where(stats => stats.LeagueId == LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Player);

                List<PlayerAggregationData> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                return materializedStats
                    .Select((stat, i) => new PlayerRecordDetails(stat.Year, stat.Week, i, new(recordTypeId), stat.Player, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordDetails>()
                    .ToList();
            }

            private async Task<List<TEntity>> MaterializeFilteredAndSortedStats<TEntity>(IQueryable<TEntity> baseQuery, RecordMetricProjector<TEntity> projector)
            {
                IQueryable<TEntity> filteredQuery = projector.ApplyFilter(baseQuery);
                IQueryable<TEntity> filteredAndSortedQuery = projector.ApplySort(filteredQuery);

                return await filteredAndSortedQuery.Take(10).ToListAsync();
            }
        }
    }
}
