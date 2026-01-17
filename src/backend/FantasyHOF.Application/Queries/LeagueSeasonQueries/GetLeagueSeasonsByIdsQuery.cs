using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonQueries
{
    public sealed record GetLeagueSeasonsByIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeason>>
    {
        public sealed class GetLeagueSeasonsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonsByIdsQuery, IEnumerable<LeagueSeason>>
        {
            public async Task<IEnumerable<LeagueSeason>> Handle(
                GetLeagueSeasonsByIdsQuery request,
                CancellationToken ct)
            {
                return await database.LeagueSeasons
                    .AsNoTracking()
                    .Where(season => request.LeagueSeasonIds.Contains(season.Id))
                    .ToListAsync(ct);
            }
        }
    }
}
