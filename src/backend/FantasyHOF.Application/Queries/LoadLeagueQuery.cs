using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries
{
    public sealed record LoadLeagueQuery(int Id) : IRequest<League?>;

    public sealed class LoadLeagueQueryHandler : IRequestHandler<LoadLeagueQuery, League?>
    {
        private readonly FantasyHOFDBContext _context;

        public LoadLeagueQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<League?> Handle(LoadLeagueQuery request, CancellationToken cancellationToken)
        {
            return await _context.Leagues.FindAsync(request.Id);
        }
    }
}
