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
    public sealed record GetLeagueRecordsQuery(int LeagueId) : IRequest<LeagueRecordSummary?>
    {
        public sealed class GetLeagueRecordsQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetLeagueRecordsQuery, LeagueRecordSummary?>
        {
            public async Task<LeagueRecordSummary?> Handle(GetLeagueRecordsQuery request, CancellationToken cancellationToken)
            {
                List<LeagueMemberAggregateStats> aggregateStats = await database.LeagueMemberAggregateStats
                    .AsNoTracking()
                    .Include(x => x.Member)
                    .Where(x => x.LeagueId == request.LeagueId)
                    .ToListAsync();

                return LeagueRecordSummary.FromAggregateStats(aggregateStats);
            }
        }
    }
}
