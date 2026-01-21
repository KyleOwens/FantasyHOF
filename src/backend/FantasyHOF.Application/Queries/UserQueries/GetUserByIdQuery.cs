using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public record GetUserByIdQuery(string UserId)
        : IRequest<User?>
    {
        public class GetUserByIdQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetUserByIdQuery, User?>
        {
            public async Task<User?> Handle(GetUserByIdQuery request, CancellationToken ct)
            {
                return await database.Users
                    .FirstOrDefaultAsync(user => user.Id == request.UserId, ct);
            }
        }
    }
}