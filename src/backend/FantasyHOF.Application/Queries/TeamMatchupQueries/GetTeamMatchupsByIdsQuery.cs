using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamMatchupQueries
{
    public sealed record GetTeamMatchupsByIdsQuery(IEnumerable<int> TeamMatchupIds)
        : IRequest<IEnumerable<TeamMatchup>>
    {
        public sealed class GetTeamMatchupsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetTeamMatchupsByIdsQuery, IEnumerable<TeamMatchup>>
        {
            public async Task<IEnumerable<TeamMatchup>> Handle(
                GetTeamMatchupsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.TeamMatchups
                    .AsNoTracking()
                    .Where(matchup => request.TeamMatchupIds.Contains(matchup.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}