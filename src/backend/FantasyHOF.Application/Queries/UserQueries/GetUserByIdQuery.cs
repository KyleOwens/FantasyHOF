using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public record GetUserByIdQuery(Guid UserId)
        : IRequest<User?>
    {
        public class GetUserByIdQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser)
            : IRequestHandler<GetUserByIdQuery, User?>
        {
            public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken ct)
            {
                return await database.Users
                    .SingleAsync(user => user.Id == currentUser.Id, ct);
            }
        }
    }
}