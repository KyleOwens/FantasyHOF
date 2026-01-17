using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.FantasyMemberQueries
{
    public sealed record GetFantasyMembersByIdsQuery(IEnumerable<int> FantasyMemberIds)
        : IRequest<IEnumerable<FantasyMember>>
    {
        public sealed class GetFantasyMembersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetFantasyMembersByIdsQuery, IEnumerable<FantasyMember>>
        {
            private readonly FantasyHOFDBContext _context = database;

            public async Task<IEnumerable<FantasyMember>> Handle(
                GetFantasyMembersByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await _context.FantasyMembers
                    .AsNoTracking()
                    .Where(member => request.FantasyMemberIds.Contains(member.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}