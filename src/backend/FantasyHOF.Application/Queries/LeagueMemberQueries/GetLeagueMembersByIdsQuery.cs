using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueMemberQueries
{
    public sealed record GetLeagueMembersByIdsQuery(IEnumerable<LeagueMemberId> LeagueMemberIds)
        : IRequest<IEnumerable<LeagueMember>>
    {
        public sealed class GetLeagueMembersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueMembersByIdsQuery, IEnumerable<LeagueMember>>
        {
            public async Task<IEnumerable<LeagueMember>> Handle(
                GetLeagueMembersByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.LeagueMembers
                    .AsNoTracking()
                    .Where(leagueMember => request.LeagueMemberIds
                        .Any(id => id.LeagueId == leagueMember.LeagueId && id.MemberId == leagueMember.MemberId))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}