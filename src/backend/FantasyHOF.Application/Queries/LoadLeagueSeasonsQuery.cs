using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries
{
    public sealed record LoadLeagueSeasonsQuery(int Id) : IRequest<IEnumerable<LeagueSeason>>;

    public sealed class LoadLeagueSeasonsQueryHandler : IRequestHandler<LoadLeagueSeasonsQuery, IEnumerable<LeagueSeason>>
    {
        private readonly FantasyHOFDBContext _context;

        public LoadLeagueSeasonsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeason>> Handle(LoadLeagueSeasonsQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeagueSeasons
                .Where(season => season.LeagueId == request.Id)
                .ToListAsync();
        }
    }
}
