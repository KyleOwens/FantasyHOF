
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries
{
    public sealed record GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery(IEnumerable<LeagueSeasonMemberId> LeagueSeasonMemberIds)
        : IRequest<IEnumerable<LeagueSeasonMemberTeam>>;

    public sealed class GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery, IEnumerable<LeagueSeasonMemberTeam>>
    {
        public async Task<IEnumerable<LeagueSeasonMemberTeam>> Handle(GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery request, CancellationToken ct)
        {
            IEnumerable<LeagueSeasonMemberId> searchIds = request.LeagueSeasonMemberIds;
            HashSet<LeagueSeasonMemberId> idSet = [.. searchIds];

            IEnumerable<int> seasonIds = searchIds.Select(x => x.LeagueSeasonId).Distinct();
            IEnumerable<int> memberIds = searchIds.Select(x => x.MemberId).Distinct();

            List<LeagueSeasonMemberTeam> unfilteredResults = await database.LeagueSeasonMemberTeams
                .AsNoTracking()
                .Where(memberTeam => seasonIds.Contains(memberTeam.LeagueSeasonId)
                          && memberIds.Contains(memberTeam.MemberId))
                .ToListAsync(ct);

            return unfilteredResults
                .Where(memberTeam => idSet.Contains(new LeagueSeasonMemberId(memberTeam.LeagueSeasonId, memberTeam.MemberId)));
        }
    }
}
