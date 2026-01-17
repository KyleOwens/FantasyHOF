using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeaguesByIdsQuery(IEnumerable<int> LeagueIds)
        : IRequest<IEnumerable<League>>
    {
        public sealed class GetLeaguesByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeaguesByIdsQuery, IEnumerable<League>>
        {
            public async Task<IEnumerable<League>> Handle(GetLeaguesByIdsQuery request, CancellationToken ct)
            {
                return await database.Leagues
                    .AsNoTracking()
                    .Where(league => request.LeagueIds.Contains(league.Id))
                    .ToListAsync(ct);
            }
        }
    }
}
