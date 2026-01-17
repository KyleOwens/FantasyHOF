using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries
{
    public sealed record GetLeagueSeasonSettingsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeasonSettings>>
    {
        public sealed class GetLeagueSeasonSettingsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonSettingsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonSettings>>
        {
            public async Task<IEnumerable<LeagueSeasonSettings>> Handle(GetLeagueSeasonSettingsByLeagueSeasonIdsQuery request, CancellationToken ct)
            {
                return await database.LeagueSeasonSettings
                    .AsNoTracking()
                    .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId))
                    .ToListAsync(ct);
            }
        }
    }
}
