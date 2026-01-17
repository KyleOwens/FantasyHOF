using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries
{
    public sealed record GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeasonScoringSettings>>;

    public sealed class GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonScoringSettings>>
    {
        public async Task<IEnumerable<LeagueSeasonScoringSettings>> Handle(GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery request, CancellationToken ct)
        {
            return await database.LeagueSeasonScoringSettings
                .AsNoTracking()
                .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId))
                .ToListAsync(ct);
        }
    }
}


