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
    public sealed record GetLeagueSeasonsByIdsQuery(IEnumerable<int> LeagueSeasonIds) 
        : IRequest<IEnumerable<LeagueSeason>>
    {
        public sealed class GetLeagueSeasonsByIdsQueryHandler(FantasyHOFDBContext context)
                        : IRequestHandler<GetLeagueSeasonsByIdsQuery, IEnumerable<LeagueSeason>>
        {
            private readonly FantasyHOFDBContext _context = context;

            public async Task<IEnumerable<LeagueSeason>> Handle(
                GetLeagueSeasonsByIdsQuery request, 
                CancellationToken cancellationToken)
            {
                return await _context.LeagueSeasons
                    .Where(season => request.LeagueSeasonIds.Contains(season.Id))
                    .ToListAsync();
            }
        }
    }
}
