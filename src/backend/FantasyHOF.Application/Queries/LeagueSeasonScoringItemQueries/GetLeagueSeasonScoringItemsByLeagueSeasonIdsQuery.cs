using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries
{
    public sealed record GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeasonScoringItem>>;

    public sealed class GetLeagueSeasonScoringItemsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonScoringItem>>
    {
        public async Task<IEnumerable<LeagueSeasonScoringItem>> Handle(GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
        {
            return await database.LeagueSeasonScoringItems
                .AsNoTracking()
                .Where(item => request.LeagueSeasonIds.Contains(item.LeagueSeasonId))
                .ToListAsync(cancellationToken);
        }
    }
}


