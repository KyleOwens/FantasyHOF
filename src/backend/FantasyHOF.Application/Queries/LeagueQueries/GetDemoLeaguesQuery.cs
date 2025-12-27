using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetDemoLeaguesQuery() : IRequest<IEnumerable<League>>
    {
        public sealed class GetDemoLeaguesQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetDemoLeaguesQuery, IEnumerable<League>>
        {
            public async Task<IEnumerable<League>> Handle(GetDemoLeaguesQuery request, CancellationToken cancellationToken)
            {
                return database.Leagues.Where(league => league.UserId == null);
            }
        }
    }
}
