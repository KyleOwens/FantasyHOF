
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries
{
    public sealed record GetLeagueSeasonMemberTeamsByIdsQuery(IEnumerable<LeagueSeasonMemberTeamId> LeagueSeasonMemberTeamIds)
        : IRequest<IEnumerable<LeagueSeasonMemberTeam>>
    {
        public sealed class GetLeagueSeasonMemberTeamsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonMemberTeamsByIdsQuery, IEnumerable<LeagueSeasonMemberTeam>>
        {
            public async Task<IEnumerable<LeagueSeasonMemberTeam>> Handle(
                GetLeagueSeasonMemberTeamsByIdsQuery request,
                CancellationToken ct)
            {
                List<int> leagueSeasonIds = [.. request.LeagueSeasonMemberTeamIds.Select(id => id.LeagueSeasonId).Distinct()];
                List<int> memberIds = [.. request.LeagueSeasonMemberTeamIds.Select(id => id.MemberId).Distinct()];
                List<int> teamIds = [.. request.LeagueSeasonMemberTeamIds.Select(id => id.TeamId).Distinct()];

                List<LeagueSeasonMemberTeam> candidates = await database.LeagueSeasonMemberTeams
                    .AsNoTracking()
                    .Where(memberTeam => leagueSeasonIds.Contains(memberTeam.LeagueSeasonId) &&
                                         memberIds.Contains(memberTeam.MemberId) &&
                                         teamIds.Contains(memberTeam.TeamId))
                    .ToListAsync(ct);

                return [.. candidates
                    .Where(memberTeam => request.LeagueSeasonMemberTeamIds
                        .Any(id => id.LeagueSeasonId == memberTeam.LeagueSeasonId &&
                                    id.MemberId == memberTeam.MemberId &&
                                    id.TeamId == memberTeam.TeamId))];
            }
        }
    }
}
