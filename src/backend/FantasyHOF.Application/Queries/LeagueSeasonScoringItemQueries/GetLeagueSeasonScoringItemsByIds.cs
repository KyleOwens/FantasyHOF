using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries
{
    public sealed record GetLeagueSeasonScoringItemsByIdsQuery(IEnumerable<int> LeagueSeasonScoringItemIds)
        : IRequest<IEnumerable<LeagueSeasonScoringItem>>
    {
        public sealed class GetLeagueSeasonScoringItemsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonScoringItemsByIdsQuery, IEnumerable<LeagueSeasonScoringItem>>
        {
            public async Task<IEnumerable<LeagueSeasonScoringItem>> Handle(
                GetLeagueSeasonScoringItemsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.LeagueSeasonScoringItems
                    .AsNoTracking()
                    .Where(item => request.LeagueSeasonScoringItemIds.Contains(item.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
