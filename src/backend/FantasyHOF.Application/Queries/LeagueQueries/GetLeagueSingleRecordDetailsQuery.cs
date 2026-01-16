using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Registries;
using FantasyHOF.Application.Types.Queries.Records;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueSingleRecordDetailsQuery(int LeagueId, RecordTypeId RecordType) : IRequest<RecordDetails>
    {
        public sealed class GetLeagueSingleRecordDetailsQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetLeagueSingleRecordDetailsQuery, RecordDetails>
        {
            public Task<RecordDetails> Handle(GetLeagueSingleRecordDetailsQuery request, CancellationToken cancellationToken)
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
                        throw new InvalidOperationException("Record category not yet supported");
                }
            }

            private async Task<RecordDetails> LoadLeagueRecordDetail(int leagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<LeagueMemberAggregatedStats> projector = new(recordTypeId);

                IQueryable<LeagueMemberAggregatedStats> baseQuery = database.LeagueMemberAggregatedStats
                    .Where(stats => stats.LeagueId == leagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                List<LeagueMemberAggregatedStats> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                List<RecordEntry> entries = materializedStats
                    .Select((stat, i) => new LeagueRecordEntry(i + 1, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>()
                    .ToList();

                RecordMetadata metadata = new(recordTypeId);

                return new(metadata, entries);
            }

            private async Task<RecordDetails> LoadSeasonalRecordDetails(int LeagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<LeagueSeasonMemberAggregatedStats> projector = new(recordTypeId);

                IQueryable<LeagueSeasonMemberAggregatedStats> baseQuery = database.LeagueSeasonMemberAggregatedStats
                    .Where(stats => stats.LeagueId == LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                List<LeagueSeasonMemberAggregatedStats> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                List<RecordEntry> entries = materializedStats
                    .Select((stat, i) => new SeasonalRecordEntry(stat.Year, i + 1, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>()
                    .ToList();

                RecordMetadata metadata = new(recordTypeId);

                return new(metadata, entries);
            }

            private async Task<RecordDetails> LoadWeeklyRecordDetails(int LeagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<WeeklyAggregationData> projector = new(recordTypeId);

                IQueryable<WeeklyAggregationData> baseQuery = database.WeeklyAggregationData
                    .Where(stats => stats.LeagueId == LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member);

                List<WeeklyAggregationData> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                List<RecordEntry> entries = materializedStats
                    .Select((stat, i) => new WeeklyRecordEntry(stat.Year, stat.Week, i + 1, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>()
                    .ToList();

                RecordMetadata metadata = new(recordTypeId);

                return new(metadata, entries);
            }

            private async Task<RecordDetails> LoadPlayerRecordDetails(int LeagueId, RecordTypeId recordTypeId)
            {
                RecordMetricProjector<PlayerAggregationData> projector = new(recordTypeId);

                IQueryable<PlayerAggregationData> baseQuery = database.PlayerAggregationData
                    .Where(stats => stats.LeagueId == LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Player)
                    .Include(x => x.Position);

                List<PlayerAggregationData> materializedStats = await MaterializeFilteredAndSortedStats(
                    baseQuery,
                    projector);

                List<RecordEntry> entries = materializedStats
                    .Select((stat, i) => new PlayerRecordEntry(stat.Year, stat.Week, i + 1, stat.Player, stat.Position, projector.GetMetric(stat), stat.MemberDetails))
                    .Cast<RecordEntry>()
                    .ToList();

                RecordMetadata metadata = new(recordTypeId);

                return new(metadata, entries);
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
