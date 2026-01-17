using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonQueries
{
    public sealed record GetLeagueSeasonsByLeagueIdsQuery(IEnumerable<int> LeagueIds)
        : IRequest<IEnumerable<LeagueSeason>>
    {
        public sealed class GetLeagueSeasonsByLeagueIdQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueSeasonsByLeagueIdsQuery, IEnumerable<LeagueSeason>>
        {
            public async Task<IEnumerable<LeagueSeason>> Handle(GetLeagueSeasonsByLeagueIdsQuery request, CancellationToken cancellationToken)
            {
                return await database.LeagueSeasons
                    .AsNoTracking()
                    .Where(season => request.LeagueIds.Contains(season.LeagueId))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
