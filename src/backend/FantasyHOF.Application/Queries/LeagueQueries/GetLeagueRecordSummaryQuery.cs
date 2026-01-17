using FantasyHOF.Application.Types.Queries.Records;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueRecordSummaryQuery(int LeagueId)
        : IRequest<LeagueRecordSummary?>
    {
        public sealed class GetLeagueRecordSummaryQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueRecordSummaryQuery, LeagueRecordSummary?>
        {
            public async Task<LeagueRecordSummary?> Handle(GetLeagueRecordSummaryQuery request, CancellationToken cancellationToken)
            {
                List<LeagueMemberAggregatedStats> allTimeStatsByMember = await database.LeagueMemberAggregatedStats
                   .AsNoTracking()
                   .Where(x => x.LeagueId == request.LeagueId)
                   .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                   .ToListAsync(cancellationToken);

                List<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason = await database.LeagueSeasonMemberAggregatedStats
                    .AsNoTracking()
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                    .ToListAsync(cancellationToken);

                List<WeeklyAggregationData> weeklyAggregationData = await database.WeeklyAggregationData
                    .AsNoTracking()
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                    .ToListAsync(cancellationToken);

                List<PlayerAggregationData> playerAggregationData = await database.PlayerAggregationData
                    .AsNoTracking()
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.MemberDetails)
                        .ThenInclude(x => x.Member)
                    .Include(x => x.Player)
                    .ToListAsync(cancellationToken);

                if (allTimeStatsByMember.Count == 0) return null;

                return LeagueRecordSummary.FromAggregateLeagueStats(allTimeStatsByMember, statsByMemberAndSeason, weeklyAggregationData, playerAggregationData);
            }
        }
    }
}
