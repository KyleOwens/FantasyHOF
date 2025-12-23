
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries
{
    public sealed record GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds) : IRequest<IEnumerable<LeagueSeasonScoringSettings>>;

    public sealed class GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQueryHandler : IRequestHandler<GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonScoringSettings>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeasonScoringSettings>> Handle(GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeagueSeasonScoringSettings
                .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId))
                .ToListAsync();
        }
    }
}


