
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
    public sealed record GetMatchupRosterSpotsByTeamMatchupIdsQuery(IEnumerable<int> TeamMatchupIds) : IRequest<IEnumerable<MatchupRosterSpot>>;

    public sealed class GetMatchupRosterSpotsByTeamMatchupIdsQueryHandler : IRequestHandler<GetMatchupRosterSpotsByTeamMatchupIdsQuery, IEnumerable<MatchupRosterSpot>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetMatchupRosterSpotsByTeamMatchupIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<MatchupRosterSpot>> Handle(GetMatchupRosterSpotsByTeamMatchupIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.MatchupRosterSpots
                .Where(rosterSpot => request.TeamMatchupIds.Contains(rosterSpot.MatchupId))
                .ToListAsync();
        }
    }
}
