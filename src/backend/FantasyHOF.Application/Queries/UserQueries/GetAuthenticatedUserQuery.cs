using FantasyHOF.Application.Mutations;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Application.Authentication;

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
