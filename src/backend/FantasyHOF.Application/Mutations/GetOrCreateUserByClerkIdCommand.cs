using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Mutations
{
    public record GetOrCreateUserByClerkIdCommand(string ClerkUserId) : IRequest<User>
    {
        public class GetOrCreateUserByClerkIdCommandHandler(FantasyHOFDBContext context)
            : IRequestHandler<GetOrCreateUserByClerkIdCommand, User>
        {
            private readonly FantasyHOFDBContext _context = context;

            public async Task<User> Handle(GetOrCreateUserByClerkIdCommand request, CancellationToken cancellationToken)
            {
                User? existingUser = await _context.Users
                    .SingleOrDefaultAsync(user => user.ClerkId == request.ClerkUserId);

                if (existingUser != null) return existingUser;

                User user = new(request.ClerkUserId);

                _context.Users.Add(user);

                try
                {
                    await _context.SaveChangesAsync(cancellationToken);
                }
                catch (DbUpdateException)
                {
                    user = await _context.Users
                        .SingleAsync(user => user.ClerkId == request.ClerkUserId, cancellationToken);
                }

                return user;
            }
        }
    }
}
