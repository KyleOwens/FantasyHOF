using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    .Where(settings => request.LeagueSeasonIds.Contains(settings.LeagueSeasonId))
                    .ToListAsync();
            }
        }
    }
}
