
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries
{
    public sealed record GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds) : IRequest<IEnumerable<LeagueSeasonScheduleSettings>>;

    public sealed class GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQueryHandler : IRequestHandler<GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonScheduleSettings>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeasonScheduleSettings>> Handle(GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
        {
            return _context.LeagueSeasonScheduleSettings
                .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId));
        }
    }
}

