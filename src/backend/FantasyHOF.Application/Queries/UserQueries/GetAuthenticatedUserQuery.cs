using FantasyHOF.Application.Mutations;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using MediatR;
using System.Security.Authentication;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public sealed record GetAuthenticatedUserQuery : IRequest<User>
    {
        public sealed class GetAuthenticatedUserQueryHandler(ICurrentUserService currentUser, IMediator mediator) : IRequestHandler<GetAuthenticatedUserQuery, User>
        {
            public async Task<User> Handle(GetAuthenticatedUserQuery request, CancellationToken ct)
            {
                if (!currentUser.IsAuthenticated) throw new AuthenticationException("No authenticated user detected");

                return await mediator.Send(new GetOrCreateUserByClerkIdCommand(currentUser.ClerkUserId), ct);
            }
        }
    }
}
