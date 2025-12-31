using FantasyHOF.Application.Queries.MatchupTeamDetailsQueries;
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
    [ExtendObjectType<MatchupTeamDetails>]
    internal class MatchupTeamDetailsTypeExtension
	{
		[ID<MatchupOutcome>]
		public int MatchupOutcomeId([Parent] MatchupTeamDetails teamDetails) => (int) teamDetails.MatchupOutcomeId;

		[ID<Team>]
		public int TeamId([Parent] MatchupTeamDetails teamDetails) => teamDetails.TeamId;

        public async Task<Team> GetTeamAsync(
			[Parent] MatchupTeamDetails teamDetails,
			ITeamsByIdsDataLoader teams,
			CancellationToken cancellationToken)
		{
			return await teams.LoadRequiredAsync(teamDetails.TeamId, cancellationToken);
		}

		public async Task<MatchupOutcome> GetOutcomeAsync(
			[Parent] MatchupTeamDetails teamDetails,
			IMatchupOutcomesByIdsDataLoader outcomes,
			CancellationToken cancellationToken)
		{
			return await outcomes.LoadRequiredAsync(teamDetails.MatchupOutcomeId, cancellationToken);
		}

		public async Task<IEnumerable<MatchupRosterSpot>> GetMatchupRosterSpotsAsync(
			[Parent] MatchupTeamDetails teamDetails,
			IMatchupRosterSpotsByMatchupTeamDetailsIdsDataLoader rosterSpots,
			CancellationToken cancellationToken)
		{
			return await rosterSpots.LoadAsync(teamDetails.Id, cancellationToken) ?? [];
		}
		
		public static async Task<MatchupTeamDetails?> GetMatchupTeamDetailsAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetMatchupTeamDetailsByIdQuery(id), cancellationToken);
		}
    }
}
