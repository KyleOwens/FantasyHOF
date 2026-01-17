using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

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
                if (!currentUser.IsAuthenticated) throw new UnauthorizedAccessException();

                Guid userId = await currentUser
                    .GetUserIdAsync(ct);
                User user = await database.Users
                    .SingleAsync(x => x.ClerkId == currentUser.ClerkUserId, ct);

                return database.Leagues
                    .Where(x => x.UserId == user.Id)
                    .OrderBy(x => x.Id);
            }
        }
    }
}
