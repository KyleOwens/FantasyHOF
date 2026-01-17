using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.PlayerQueries
{
    public sealed record GetPlayersByIdsQuery(IEnumerable<int> PlayerIds)
        : IRequest<IEnumerable<Player>>
    {
        public sealed class GetPlayersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetPlayersByIdsQuery, IEnumerable<Player>>
        {
            public async Task<IEnumerable<Player>> Handle(
                GetPlayersByIdsQuery request,
                CancellationToken ct)
            {
                return await database.Players
                    .AsNoTracking()
                    .Where(player => request.PlayerIds.Contains(player.Id))
                    .ToListAsync(ct);
            }
        }
    }
}