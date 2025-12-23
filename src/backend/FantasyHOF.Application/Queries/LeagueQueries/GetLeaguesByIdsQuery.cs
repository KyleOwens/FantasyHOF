using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.Leagues
{
    public sealed record GetLeaguesByIdsQuery(IEnumerable<int> LeagueIds) : IRequest<IEnumerable<League>>
    {
        public sealed class GetLeaguesByIdsQueryHandler : IRequestHandler<GetLeaguesByIdsQuery, IEnumerable<League>>
        {
            private readonly FantasyHOFDBContext _context;

            public GetLeaguesByIdsQueryHandler(FantasyHOFDBContext context) => _context = context;
            
            public async Task<IEnumerable<League>> Handle(GetLeaguesByIdsQuery request, CancellationToken cancellationToken)
            {
                return await _context.Leagues
                    .Where(league => request.LeagueIds.Contains(league.Id))
                    .ToListAsync();
            }
        }
    }
}
