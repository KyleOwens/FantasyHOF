using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetUserLeaguesQuery
        : IRequest<IQueryable<League>>
    {
        public sealed class GetUserLeaguesQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser)
            : IRequestHandler<GetUserLeaguesQuery, IQueryable<League>>
        {
            public async Task<IQueryable<League>> Handle(GetUserLeaguesQuery request, CancellationToken ct)
            {
                return database.Leagues
                    .Where(x => x.UserId == currentUser.Id)
                    .OrderBy(x => x.Id);
            }
        }
    }
}
