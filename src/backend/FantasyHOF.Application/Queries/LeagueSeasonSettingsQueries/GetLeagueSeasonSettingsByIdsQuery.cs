using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries
{
    public sealed record GetLeagueSeasonSettingsByIdsQuery(IEnumerable<int> LeagueSeasonSettingsIds)
        : IRequest<IEnumerable<LeagueSeasonSettings>>
    {
        public sealed class GetLeagueSeasonSettingsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonSettingsByIdsQuery, IEnumerable<LeagueSeasonSettings>>
        {
            public async Task<IEnumerable<LeagueSeasonSettings>> Handle(
                GetLeagueSeasonSettingsByIdsQuery request,
                CancellationToken ct)
            {
                return await database.LeagueSeasonSettings
                    .AsNoTracking()
                    .Where(settings => request.LeagueSeasonSettingsIds.Contains(settings.Id))
                    .ToListAsync(ct);
            }
        }
    }
}
