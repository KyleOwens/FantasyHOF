using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamMatchupQueries
{
    public sealed record GetTeamMatchupsByTeamIdsQuery(IEnumerable<int> TeamIds)
        : IRequest<IEnumerable<TeamMatchup>>
    {
        public sealed class GetTeamMatchupsByTeamIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetTeamMatchupsByTeamIdsQuery, IEnumerable<TeamMatchup>>
        {
            public async Task<IEnumerable<TeamMatchup>> Handle(GetTeamMatchupsByTeamIdsQuery request, CancellationToken ct)
            {
                return await database.TeamMatchups
                    .AsNoTracking()
                    .Where(matchup => request.TeamIds.Contains(matchup.TeamId))
                    .ToListAsync(ct);
            }
        }
    }
}

