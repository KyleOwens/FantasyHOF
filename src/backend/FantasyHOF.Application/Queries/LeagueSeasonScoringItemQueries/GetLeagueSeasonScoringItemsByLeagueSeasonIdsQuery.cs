
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries
{
    public sealed record GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds) : IRequest<IEnumerable<LeagueSeasonScoringItem>>;

    public sealed class GetLeagueSeasonScoringItemsByLeagueSeasonIdsQueryHandler : IRequestHandler<GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonScoringItem>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonScoringItemsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeasonScoringItem>> Handle(GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeagueSeasonScoringItems
                .Where(item => request.LeagueSeasonIds.Contains(item.LeagueSeasonId))
                .ToListAsync();
        }
    }
}


