using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.Domain.Types.Views;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.TestQueries
{
    public sealed record GetLeagueRecordsQuery(int LeagueId) : IRequest<LeagueRecordSummary?>
    {
        public sealed class GetLeagueRecordsQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetLeagueRecordsQuery, LeagueRecordSummary?>
        {
            public async Task<LeagueRecordSummary?> Handle(GetLeagueRecordsQuery request, CancellationToken cancellationToken)
            {
                List<LeagueMemberAggregatedStats> allTimeStatsByMember = await database.LeagueMemberAggregatedStats
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.Member)
                    .ToListAsync();

                List<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason = await database.LeagueSeasonMemberAggregatedStats
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.Member)
                    .ToListAsync();

                List<WeeklyAggregationData> weeklyAggregationData = await database.WeeklyAggregationData
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.Member)
                    .ToListAsync();

                List<PlayerAggregationData> playerAggregationData = await database.PlayerAggregationData
                    .Where(x => x.LeagueId == request.LeagueId)
                    .Include(x => x.Member)
                    .Include(x => x.Player)
                    .ToListAsync();

                if (allTimeStatsByMember.Count == 0) return null;

                return LeagueRecordSummary.FromAggregateLeagueStats(allTimeStatsByMember, statsByMemberAndSeason, weeklyAggregationData, playerAggregationData);
            }
        }
    }
}
