using FantasyHOF.Application.Authentication;
using FantasyHOF.Application.Mutations;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetUserLeaguesQuery : IRequest<List<League>>
    {
        public sealed class GetUserLeaguesQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser, IMediator mediator) : IRequestHandler<GetUserLeaguesQuery, List<League>>
        {
            public async Task<List<League>> Handle(GetUserLeaguesQuery request, CancellationToken cancellationToken)
            {
                if (!currentUser.IsAuthenticated) return [];

                User user = await mediator.Send(new GetOrCreateUserByClerkIdCommand(currentUser.ClerkUserId));

                return await database.Leagues
                    .Where(x => x.UserId == user.Id)
                    .ToListAsync();
            }
        }
    }
}
