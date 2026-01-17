using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Mutations
{
    public record GetOrCreateUserByClerkIdCommand(string ClerkUserId)
        : IRequest<User>
    {
        public class GetOrCreateUserByClerkIdCommandHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetOrCreateUserByClerkIdCommand, User>
        {
            private readonly FantasyHOFDBContext _context = database;

            public async Task<User> Handle(GetOrCreateUserByClerkIdCommand request, CancellationToken ct)
            {
                User? existingUser = await _context.Users
                    .SingleOrDefaultAsync(user => user.ClerkId == request.ClerkUserId);

                if (existingUser != null) return existingUser;

                User user = new(request.ClerkUserId);

                _context.Users.Add(user);

                try
                {
                    await _context.SaveChangesAsync(ct);
                }
                catch (DbUpdateException)
                {
                    user = await _context.Users
                        .SingleAsync(user => user.ClerkId == request.ClerkUserId, ct);
                }

                return user;
            }
        }
    }
}
