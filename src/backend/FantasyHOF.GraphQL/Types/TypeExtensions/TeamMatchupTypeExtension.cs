using FantasyHOF.Application.Queries.TeamMatchupQueries;
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
    [ExtendObjectType<TeamMatchup>]
    internal class TeamMatchupTypeExtension
	{
		[ID<Team>]
		public int TeamId([Parent] TeamMatchup teamMatchup) => teamMatchup.TeamId;

		[ID<Team>]
		public int? OpponentTeamId([Parent] TeamMatchup teamMatchup) => teamMatchup.OpponentTeamId;

		[ID<MatchupOutcome>]
		public int MatchupOutcomeId([Parent] TeamMatchup teamMatchup) => (int)teamMatchup.MatchupOutcomeId;

		[ID<MatchupType>]
		public int MatchupTypeId([Parent] TeamMatchup teamMatchup) => (int)teamMatchup.MatchupTypeId;

		public async Task<Team?> GetOpponentAsync(
			[Parent] TeamMatchup teamMatchup,
			ITeamssByIdsDataLoader teams,
			CancellationToken cancellationToken)
		{
            if (teamMatchup.OpponentTeamId is null) return null;

            return await teams.LoadAsync(teamMatchup.OpponentTeamId.Value);
		}

		public async Task<MatchupOutcome> GetMatchupOutcomeAsync(
			[Parent] TeamMatchup teamMatchup,
			IMatchupOutcomesByIdsDataLoader outcomes,
			CancellationToken cancellationToken)
		{
			return await outcomes.LoadRequiredAsync(teamMatchup.MatchupOutcomeId, cancellationToken);
		}

		public async Task<MatchupType> GetMatchupTypeAsync(
			[Parent] TeamMatchup teamMatchup,
			IMatchupTypesByIdsDataLoader types,
			CancellationToken cancellationToken)
		{
			return await types.LoadRequiredAsync(teamMatchup.MatchupTypeId, cancellationToken);
		}

		public async Task<IEnumerable<MatchupRosterSpot>> MatchupRosterSpots(
			[Parent] TeamMatchup teamMatchup,
			IMatchupRosterSpotsByTeamMatchupIdsDataLoader rosterSpots,
			CancellationToken cancellationToken)
		{
			return await rosterSpots.LoadAsync(teamMatchup.Id, cancellationToken) ?? [];
		}

        public static async Task<TeamMatchup?> GetTeamMatchupAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetTeamMatchupByIdQuery(id), cancellationToken);
		}
    }
}
