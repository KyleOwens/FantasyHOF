using FantasyHOF.Application.Types.Configuration;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetDemoLeaguesQuery()
        : IRequest<IEnumerable<League>>
    {
        public sealed class GetDemoLeaguesQueryHandler(FantasyHOFDBContext database, IOptions<AppConfig> appConfig)
            : IRequestHandler<GetDemoLeaguesQuery, IEnumerable<League>>
        {
            public async Task<IEnumerable<League>> Handle(GetDemoLeaguesQuery request, CancellationToken ct)
            {
                User adminUser = await database.Users
                    .Where(x => x.ClerkId == appConfig.Value.AdminClerkUserId)
                    .SingleAsync(ct);

                return await database.Leagues
                    .AsNoTracking()
                    .Where(league => league.UserId == adminUser.Id)
                    .ToListAsync(ct);
            }
        }
    }
}
