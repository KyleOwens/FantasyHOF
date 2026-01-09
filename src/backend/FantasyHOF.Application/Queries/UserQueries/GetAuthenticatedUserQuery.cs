using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public sealed record GetAuthenticatedUserQuery : IRequest<User>
    {
        public sealed class GetAuthenticatedUserQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser) : IRequestHandler<GetAuthenticatedUserQuery, User>
        {
            public async Task<User> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
            {
                return await database.Users.Where(x => x.ClerkId == currentUser.ClerkUserId).SingleAsync();
            }
        }
    }
}
