using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.UserQueries
{
    public sealed record GetUsersByIdsQuery(IEnumerable<string> UserIds)
        : IRequest<IEnumerable<User>>
    {
        public sealed class GetUsersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetUsersByIdsQuery, IEnumerable<User>>
        {
            public async Task<IEnumerable<User>> Handle(
                GetUsersByIdsQuery request,
                CancellationToken ct)
            {
                return await database.Users
                    .AsNoTracking()
                    .Where(user => request.UserIds.Contains(user.Id))
                    .ToListAsync(ct);
            }
        }
    }
}