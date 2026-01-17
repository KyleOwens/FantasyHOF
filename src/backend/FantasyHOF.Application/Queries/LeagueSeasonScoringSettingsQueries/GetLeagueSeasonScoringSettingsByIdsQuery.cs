using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries
{
    public sealed record GetLeagueSeasonScoringSettingsByIdsQuery(IEnumerable<int> LeagueSeasonScoringSettingsIds)
        : IRequest<IEnumerable<LeagueSeasonScoringSettings>>
    {
        public sealed class GetLeagueSeasonScoringSettingsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonScoringSettingsByIdsQuery, IEnumerable<LeagueSeasonScoringSettings>>
        {
            public async Task<IEnumerable<LeagueSeasonScoringSettings>> Handle(
                GetLeagueSeasonScoringSettingsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.LeagueSeasonScoringSettings
                    .AsNoTracking()
                    .Where(settings => request.LeagueSeasonScoringSettingsIds.Contains(settings.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
