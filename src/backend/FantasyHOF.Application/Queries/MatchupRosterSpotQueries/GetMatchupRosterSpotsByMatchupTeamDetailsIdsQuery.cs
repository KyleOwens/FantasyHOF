
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
    public sealed record GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery(IEnumerable<int> MatchupTeamDetailsIds) : IRequest<IEnumerable<MatchupRosterSpot>>;

    public sealed class GetMatchupRosterSpotsByMatchupTeamDetailsIdsQueryHandler : IRequestHandler<GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery, IEnumerable<MatchupRosterSpot>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetMatchupRosterSpotsByMatchupTeamDetailsIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<MatchupRosterSpot>> Handle(GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.MatchupRosterSpots
                .AsNoTracking()
                .Where(rosterSpot => request.MatchupTeamDetailsIds.Contains(rosterSpot.MatchupTeamDetailsId))
                .ToListAsync();
        }
    }
}
