using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
    public sealed record GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery(IEnumerable<int> MatchupTeamDetailsIds)
        : IRequest<IEnumerable<MatchupRosterSpot>>;

    public sealed class GetMatchupRosterSpotsByMatchupTeamDetailsIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery, IEnumerable<MatchupRosterSpot>>
    {
        public async Task<IEnumerable<MatchupRosterSpot>> Handle(GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery request, CancellationToken ct)
        {
            return await database.MatchupRosterSpots
                .AsNoTracking()
                .Where(rosterSpot => request.MatchupTeamDetailsIds.Contains(rosterSpot.MatchupTeamDetailsId))
                .ToListAsync(ct);
        }
    }
}
