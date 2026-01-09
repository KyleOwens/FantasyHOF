using FantasyHOF.Application.Configuration;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetDemoLeaguesQuery() : IRequest<IEnumerable<League>>
    {
        public sealed class GetDemoLeaguesQueryHandler(FantasyHOFDBContext database, IOptions<AppConfig> appConfig) : IRequestHandler<GetDemoLeaguesQuery, IEnumerable<League>>
        {
            public async Task<IEnumerable<League>> Handle(GetDemoLeaguesQuery request, CancellationToken cancellationToken)
            {
                User adminUser = await database.Users.Where(x => x.ClerkId == appConfig.Value.AdminClerkUserId).SingleAsync();
                
                return database.Leagues
                    .AsNoTracking()
                    .Where(league => league.UserId == adminUser.Id);
            }
        }
    }
}
