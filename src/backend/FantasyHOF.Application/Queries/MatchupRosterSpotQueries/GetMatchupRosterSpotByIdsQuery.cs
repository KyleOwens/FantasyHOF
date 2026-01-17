using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
    public sealed record GetMatchupRosterSpotsByIdsQuery(IEnumerable<int> MatchupRosterSpotIds)
        : IRequest<IEnumerable<MatchupRosterSpot>>
    {
        public sealed class GetMatchupRosterSpotsByIdsQueryHandler(FantasyHOFDBContext database)
                        : IRequestHandler<GetMatchupRosterSpotsByIdsQuery, IEnumerable<MatchupRosterSpot>>
        {
            public async Task<IEnumerable<MatchupRosterSpot>> Handle(
                GetMatchupRosterSpotsByIdsQuery request,
                CancellationToken ct)
            {
                return await database.MatchupRosterSpots
                    .AsNoTracking()
                    .Where(rosterSpot => request.MatchupRosterSpotIds.Contains(rosterSpot.Id))
                    .ToListAsync(ct);
            }
        }
    }
}