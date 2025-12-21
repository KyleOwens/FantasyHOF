using FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries;
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Types;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<LeagueSeasonMemberTeam>]
    internal class LeagueSeasonMemberTeamTypeExtension
    {
        [ID]
        public string Id([Parent] LeagueSeasonMemberTeam team)
            => new LeagueSeasonMemberTeamId(team.LeagueSeasonId, team.MemberId, team.TeamId).ToString();

        [ID<LeagueSeason>]
        public int LeagueSeasonId([Parent] LeagueSeasonMemberTeam team) => team.LeagueSeasonId;

        [ID<FantasyMember>]
        public int MemberId([Parent] LeagueSeasonMemberTeam team) => team.MemberId;

        [ID<Team>]
        public int TeamId([Parent] LeagueSeasonMemberTeam team) => team.TeamId;

        public async Task<Team> GetTeam(
            [Parent] LeagueSeasonMemberTeam memberTeam,
            ITeamssByIdsDataLoader teams,
            CancellationToken cancellationToken)
        {
            return await teams.LoadRequiredAsync(memberTeam.TeamId, cancellationToken);
        }

        public static async Task<LeagueSeasonMemberTeam?> GetLeagueSeasonMemberTeamAsync(
            string id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueSeasonMemberTeamByIdQuery(LeagueSeasonMemberTeamId.Parse(id)), cancellationToken);
        }
    }
}
