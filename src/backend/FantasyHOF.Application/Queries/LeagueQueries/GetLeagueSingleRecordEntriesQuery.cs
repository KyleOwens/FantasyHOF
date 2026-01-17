using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Services.Registries;
using FantasyHOF.Application.Types.Queries.Records;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueSingleRecordEntriesQuery(int LeagueId, RecordTypeId RecordType)
        : IRequest<IQueryable<RecordEntry>>
    {
        public sealed class GetLeagueSingleRecordEntriesQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSingleRecordEntriesQuery, IQueryable<RecordEntry>>
        {
            public Task<IQueryable<RecordEntry>> Handle(GetLeagueSingleRecordEntriesQuery request, CancellationToken cancellationToken)
            {
                RecordCategoryId recordCategory = request.RecordType.GetMetadata().Category;

                return recordCategory switch
                {
                    RecordCategoryId.League => LoadLeagueRecordDetail(request.LeagueId, request.RecordType),
                    RecordCategoryId.Season => LoadSeasonalRecordDetails(request.LeagueId, request.RecordType),
                    RecordCategoryId.Week => LoadWeeklyRecordDetails(request.LeagueId, request.RecordType),
                    RecordCategoryId.Player => LoadPlayerRecordDetails(request.LeagueId, request.RecordType),
                    _ => throw new InvalidOperationException("Record category not yet supported"),
                };
            }

            private async Task<IQueryable<RecordEntry>> LoadLeagueRecordDetail(int leagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<LeagueMemberAggregatedStats> projector = new(recordTypeId);

                IQueryable<LeagueMemberAggregatedStats> baseQuery = database.LeagueMemberAggregatedStats
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                IQueryable<LeagueMemberAggregatedStats> filteredAndSortedStats = await FilterAndSortStats(
                    baseQuery,
                    projector);

                return filteredAndSortedStats
                    .Select((stat) => new LeagueRecordEntry(1, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>();
            }

            private async Task<IQueryable<RecordEntry>> LoadSeasonalRecordDetails(int leagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<LeagueSeasonMemberAggregatedStats> projector = new(recordTypeId);

                IQueryable<LeagueSeasonMemberAggregatedStats> baseQuery = database.LeagueSeasonMemberAggregatedStats
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                IQueryable<LeagueSeasonMemberAggregatedStats> filteredAndSortedStats = await FilterAndSortStats(
                    baseQuery,
                    projector);

                return filteredAndSortedStats
                    .Select((stat) => new SeasonalRecordEntry(stat.Year, 1, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>();
            }

            private async Task<IQueryable<RecordEntry>> LoadWeeklyRecordDetails(int leagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<WeeklyAggregationData> projector = new(recordTypeId);

                IQueryable<WeeklyAggregationData> baseQuery = database.WeeklyAggregationData
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                IQueryable<WeeklyAggregationData> filteredAndSortedStats = await FilterAndSortStats(
                    baseQuery,
                    projector);

                return filteredAndSortedStats
                    .Select((stat) => new WeeklyRecordEntry(stat.Year, stat.Week, 1, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>();
            }

            private async Task<IQueryable<RecordEntry>> LoadPlayerRecordDetails(int leagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<PlayerAggregationData> projector = new(recordTypeId);

                IQueryable<PlayerAggregationData> baseQuery = database.PlayerAggregationData
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Player)
                    .Include(x => x.Position);

                IQueryable<PlayerAggregationData> filteredAndSortedStats = await FilterAndSortStats(
                    baseQuery,
                    projector);

                return filteredAndSortedStats
                    .Select((stat) => new PlayerRecordEntry(stat.Year, stat.Week, 1, stat.Player, stat.Position, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>();
            }

            private static async Task<IQueryable<TEntity>> FilterAndSortStats<TEntity>(IQueryable<TEntity> baseQuery, RecordMetricProjector<TEntity> projector)
            {
                IQueryable<TEntity> filteredQuery = projector.ApplyFilter(baseQuery);
                IQueryable<TEntity> filteredAndSortedQuery = projector.ApplySort(filteredQuery);

                return filteredAndSortedQuery;
            }
        }
    }
}
