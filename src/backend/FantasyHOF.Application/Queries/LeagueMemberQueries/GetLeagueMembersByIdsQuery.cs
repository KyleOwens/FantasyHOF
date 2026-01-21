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
                CancellationToken ct)
            {
                List<int> leagueIds = [.. request.LeagueMemberIds.Select(id => id.LeagueId)];
                List<int> memberIds = [.. request.LeagueMemberIds.Select(id => id.MemberId)];

                List<LeagueMember> candidates = await database.LeagueMembers
                    .AsNoTracking()
                    .Where(lm => leagueIds.Contains(lm.LeagueId) && memberIds.Contains(lm.MemberId))
                    .ToListAsync(ct);

                return [..candidates
                    .Where(lm => request.LeagueMemberIds
                        .Any(id => id.LeagueId == lm.LeagueId && id.MemberId == lm.MemberId))];
            }
        }
    }
}