
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
    public sealed record GetLeagueSeasonMembersByIdsQuery(IEnumerable<LeagueSeasonMemberId> LeagueSeasonMemberIds)
        : IRequest<IEnumerable<LeagueSeasonMember>>
    {
        public sealed class GetLeagueSeasonMembersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonMembersByIdsQuery, IEnumerable<LeagueSeasonMember>>
        {
            public async Task<IEnumerable<LeagueSeasonMember>> Handle(
                GetLeagueSeasonMembersByIdsQuery request,
                CancellationToken ct)
            {
                List<int> leagueSeasonIds = [.. request.LeagueSeasonMemberIds.Select(x => x.LeagueSeasonId)];
                List<int> memberIds = [.. request.LeagueSeasonMemberIds.Select(x => x.MemberId)];

                List<LeagueSeasonMember> candidates = await database.LeagueSeasonMembers
                    .AsNoTracking()
                    .Where(lsm => leagueSeasonIds.Contains(lsm.LeagueSeasonId) && memberIds.Contains(lsm.MemberId))
                    .ToListAsync(ct);

                return [..candidates
                    .Where(seasonMember => request.LeagueSeasonMemberIds
                        .Any(id => id.LeagueSeasonId == seasonMember.LeagueSeasonId && id.MemberId == seasonMember.MemberId))];
            }
        }
    }
}
