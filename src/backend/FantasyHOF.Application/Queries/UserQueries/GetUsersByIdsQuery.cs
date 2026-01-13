using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public sealed record GetUsersByIdsQuery(IEnumerable<Guid> UserIds)
        : IRequest<IEnumerable<User>>
    {
        public sealed class GetUsersByIdsQueryHandler(FantasyHOFDBContext context)
                        : IRequestHandler<GetUsersByIdsQuery, IEnumerable<User>>
        {
            private readonly FantasyHOFDBContext _context = context;

            public async Task<IEnumerable<User>> Handle(
                GetUsersByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.Users
                    .AsNoTracking()
                    .Where(user => request.UserIds.Contains(user.Id))
                    .ToListAsync();
            }
        }
    }
}