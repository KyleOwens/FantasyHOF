using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.LeagueSeasons
{
    public sealed record GetLeagueSeasonsByLeagueIdsQuery(IEnumerable<int> LeagueIds) : IRequest<IEnumerable<LeagueSeason>>;

    public sealed class GetLeagueSeasonsByLeagueIdQueryHandler : IRequestHandler<GetLeagueSeasonsByLeagueIdsQuery, IEnumerable<LeagueSeason>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonsByLeagueIdQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeason>> Handle(GetLeagueSeasonsByLeagueIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeagueSeasons
                .Where(season => request.LeagueIds.Contains(season.LeagueId))
                .ToListAsync();
        }
    }
}
