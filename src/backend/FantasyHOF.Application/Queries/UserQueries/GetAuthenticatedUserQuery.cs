using FantasyHOF.Application.Authentication;
using FantasyHOF.Application.Mutations;
using FantasyHOF.Domain.Entities;
using MediatR;
using System.Security.Authentication;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public sealed record GetAuthenticatedUserQuery : IRequest<User>
    {
        public sealed class GetAuthenticatedUserQueryHandler(ICurrentUserService currentUser, IMediator mediator) : IRequestHandler<GetAuthenticatedUserQuery, User>
        {
            public async Task<User> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
            {
                if (!currentUser.IsAuthenticated) throw new AuthenticationException("No authenticated user detected");

                return await mediator.Send(new GetOrCreateUserByClerkIdCommand(currentUser.ClerkUserId));
            }
        }
    }
}
