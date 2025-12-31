using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.Types;
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
    public sealed record GetLeagueRecordsQuery(int LeagueId) : IRequest<LeagueRecordSummary>
    {
        public sealed class GetLeagueRecordsQueryHandler(FantasyHOFDBContext database, IRecordCalculator recordCalculator) : IRequestHandler<GetLeagueRecordsQuery, LeagueRecordSummary>
        {
            public async Task<LeagueRecordSummary> Handle(GetLeagueRecordsQuery request, CancellationToken cancellationToken)
            {
                League league = await database.Leagues
                    .AsNoTracking()
                    .Include(x => x.Seasons)
                        .ThenInclude(x => x.Members)
                            .ThenInclude(x => x.Member)
                    .Include(x => x.Seasons)
                        .ThenInclude(x => x.Members)
                            .ThenInclude(x => x.Teams)
                                .ThenInclude(x => x.Team)
                                    .ThenInclude(x => x.Matchups)
                                        .ThenInclude(x => x.OwnerMatchupDetails)
                                            .ThenInclude(x => x.MatchupRosterSpots)
                    .Include(x => x.Seasons)
                        .ThenInclude(x => x.Members)
                            .ThenInclude(x => x.Teams)
                                .ThenInclude(x => x.Team)
                                    .ThenInclude(x => x.Matchups)
                                        .ThenInclude(x => x.OpponentMatchupDetails)
                                            .ThenInclude(x => x.MatchupRosterSpots)
                    .Include(l => l.Seasons)
                        .ThenInclude(s => s.Members)
                            .ThenInclude(m => m.Teams)
                                .ThenInclude(t => t.Team)
                                    .ThenInclude(t => t.SeasonStats)
                    .AsSplitQuery()
                    .SingleAsync(x => x.Id == request.LeagueId, cancellationToken);

                return recordCalculator.CalculateLeagueRecords(league);
            }
        }
    }
}
