using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries
{
    public sealed record GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeasonScheduleSettings>>
    {
        public sealed class GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonScheduleSettings>>
        {
            public async Task<IEnumerable<LeagueSeasonScheduleSettings>> Handle(GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
            {
                return await database.LeagueSeasonScheduleSettings
                    .AsNoTracking()
                    .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}

