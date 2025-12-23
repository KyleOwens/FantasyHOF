
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries
{
    public sealed record GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery(IEnumerable<LeagueSeasonMemberId> LeagueSeasonMemberIds) : IRequest<IEnumerable<LeagueSeasonMemberTeam>>;

    public sealed class GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQueryHandler : IRequestHandler<GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery, IEnumerable<LeagueSeasonMemberTeam>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeasonMemberTeam>> Handle(GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<LeagueSeasonMemberId> searchIds = request.LeagueSeasonMemberIds;
            HashSet<LeagueSeasonMemberId> idSet = new(searchIds);

            IEnumerable<int> seasonIds = searchIds.Select(x => x.LeagueSeasonId).Distinct();
            IEnumerable<int> memberIds = searchIds.Select(x => x.MemberId).Distinct();

            List<LeagueSeasonMemberTeam> unfilteredResults = await _context.LeagueSeasonMemberTeams
                .Where(memberTeam => seasonIds.Contains(memberTeam.LeagueSeasonId)
                          && memberIds.Contains(memberTeam.MemberId))
                .ToListAsync();

            return unfilteredResults
                .Where(memberTeam => idSet.Contains(new LeagueSeasonMemberId(memberTeam.LeagueSeasonId, memberTeam.MemberId)));
                
        }
    }
}
