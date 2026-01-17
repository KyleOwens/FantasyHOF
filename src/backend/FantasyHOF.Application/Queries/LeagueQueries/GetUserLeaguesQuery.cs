using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetUserLeaguesQuery : IRequest<IQueryable<League>>
    {
        public sealed class GetUserLeaguesQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser, IMediator mediator) : IRequestHandler<GetUserLeaguesQuery, IQueryable<League>>
        {
            public async Task<IQueryable<League>> Handle(GetUserLeaguesQuery request, CancellationToken cancellationToken)
            {
                if (!currentUser.IsAuthenticated) throw new UnauthorizedAccessException();

                User user = await mediator.Send(new GetOrCreateUserByClerkIdCommand(currentUser.ClerkUserId));

                return database.Leagues
                    .Where(x => x.UserId == user.Id)
                    .OrderBy(x => x.Id);
            }
        }
    }
}
