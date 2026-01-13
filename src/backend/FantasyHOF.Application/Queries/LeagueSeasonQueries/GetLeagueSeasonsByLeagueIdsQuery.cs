using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonQueries
{
    public sealed record GetLeagueSeasonsByLeagueIdsQuery(IEnumerable<int> LeagueIds) : IRequest<IEnumerable<LeagueSeason>>;

    public sealed class GetLeagueSeasonsByLeagueIdQueryHandler : IRequestHandler<GetLeagueSeasonsByLeagueIdsQuery, IEnumerable<LeagueSeason>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonsByLeagueIdQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeason>> Handle(GetLeagueSeasonsByLeagueIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeagueSeasons
                .AsNoTracking()
                .Where(season => request.LeagueIds.Contains(season.LeagueId))
                .ToListAsync();
        }
    }
}
