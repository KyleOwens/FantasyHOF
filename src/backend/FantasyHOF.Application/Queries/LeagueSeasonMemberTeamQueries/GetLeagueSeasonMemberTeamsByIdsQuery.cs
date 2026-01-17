
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
                return await database.LeagueSeasonMemberTeams
                    .AsNoTracking()
                    .Where(memberTeam => request.LeagueSeasonMemberTeamIds
                        .Any(id => id.LeagueSeasonId == memberTeam.LeagueSeasonId &&
                                    id.MemberId == memberTeam.MemberId &&
                                    id.TeamId == memberTeam.TeamId))
                    .ToListAsync(ct);
            }
        }
    }
}
