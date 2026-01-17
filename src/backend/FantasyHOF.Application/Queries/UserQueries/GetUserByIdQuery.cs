using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
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
                if (!currentUser.IsAuthenticated) return null;

                Guid currentUserId = await currentUser.GetUserIdAsync(ct);

                if (currentUserId != request.UserId) return null;

                return await database.Users
                    .SingleAsync(user => user.ClerkId == currentUser.ClerkUserId, ct);
            }
        }
    }
}