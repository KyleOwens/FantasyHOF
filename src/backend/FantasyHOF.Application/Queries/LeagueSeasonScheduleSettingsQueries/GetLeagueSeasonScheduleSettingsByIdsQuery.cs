using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries
{
    public sealed record GetLeagueSeasonScheduleSettingssByIdsQuery(IEnumerable<int> LeagueSeasonScheduleSettingsIds)
        : IRequest<IEnumerable<LeagueSeasonScheduleSettings>>
    {
        public sealed class GetLeagueSeasonScheduleSettingssByIdsQueryHandler(FantasyHOFDBContext database)
                        : IRequestHandler<GetLeagueSeasonScheduleSettingssByIdsQuery, IEnumerable<LeagueSeasonScheduleSettings>>
        {
            public async Task<IEnumerable<LeagueSeasonScheduleSettings>> Handle(
                GetLeagueSeasonScheduleSettingssByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.LeagueSeasonScheduleSettings
                    .AsNoTracking()
                    .Where(settings => request.LeagueSeasonScheduleSettingsIds.Contains(settings.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
