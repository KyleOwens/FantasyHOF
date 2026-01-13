using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries
{
    public sealed record GetLeagueSeasonSettingsByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds) : IRequest<IEnumerable<LeagueSeasonSettings>>
    {
        public sealed class GetLeagueSeasonSettingsByLeagueSeasonIdsQueryHandler : IRequestHandler<GetLeagueSeasonSettingsByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonSettings>>
        {
            private FantasyHOFDBContext _context;

            public GetLeagueSeasonSettingsByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

            public async Task<IEnumerable<LeagueSeasonSettings>> Handle(GetLeagueSeasonSettingsByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
            {
                return await _context.LeagueSeasonSettings
                    .AsNoTracking()
                    .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId))
                    .ToListAsync();
            }
        }
    }
}
