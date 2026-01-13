using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeaguesByIdsQuery(IEnumerable<int> LeagueIds) : IRequest<IEnumerable<League>>
    {
        public sealed class GetLeaguesByIdsQueryHandler : IRequestHandler<GetLeaguesByIdsQuery, IEnumerable<League>>
        {
            private readonly FantasyHOFDBContext _context;

            public GetLeaguesByIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

            public async Task<IEnumerable<League>> Handle(GetLeaguesByIdsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Leagues
                    .AsNoTracking()
                    .Where(league => request.LeagueIds.Contains(league.Id))
                    .ToListAsync();
            }
        }
    }
}
