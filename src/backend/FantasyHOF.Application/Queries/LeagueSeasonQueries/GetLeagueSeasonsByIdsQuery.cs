using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonQueries
{
    public sealed record GetLeagueSeasonsByIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeason>>
    {
        public sealed class GetLeagueSeasonsByIdsQueryHandler(FantasyHOFDBContext context)
                        : IRequestHandler<GetLeagueSeasonsByIdsQuery, IEnumerable<LeagueSeason>>
        {
            private readonly FantasyHOFDBContext _context = context;

            public async Task<IEnumerable<LeagueSeason>> Handle(
                GetLeagueSeasonsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.LeagueSeasons
                    .AsNoTracking()
                    .Where(season => request.LeagueSeasonIds.Contains(season.Id))
                    .ToListAsync();
            }
        }
    }
}
