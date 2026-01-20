using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public sealed record GetAuthenticatedUserQuery
        : IRequest<User>
    {
        public sealed class GetAuthenticatedUserQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser)
            : IRequestHandler<GetAuthenticatedUserQuery, User>
        {
            public async Task<User> Handle(GetAuthenticatedUserQuery request, CancellationToken ct)
            {
                return await database.Users
                    .SingleAsync(x => x.Id == currentUser.Id, ct);
            }
        }
    }
}
