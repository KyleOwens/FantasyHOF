using FantasyHOF.Application.Queries.MatchupRosterSpotQueries;
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
	[ExtendObjectType<MatchupRosterSpot>]
	internal class MatchupRosterSpotTypeExtension
	{
		[ID<TeamMatchup>]
		public int MatchupId([Parent] MatchupRosterSpot rosterSpot) => rosterSpot.MatchupId;

		[ID<Player>]
		public int PlayerId([Parent] MatchupRosterSpot rosterSpot) => rosterSpot.PlayerId;

		[ID<Position>]
		public int PositionId([Parent] MatchupRosterSpot rosterSpot) => (int) rosterSpot.PositionId;
		
		public async Task<Player> GetPlayerAsync(
			[Parent] MatchupRosterSpot rosterSpot,
			IPlayersByIdsDataLoader players,
			CancellationToken cancellationToken)
		{
			return await players.LoadRequiredAsync(rosterSpot.PlayerId, cancellationToken);
		}

		public async Task<Position> GetPositionAsync(
			[Parent] MatchupRosterSpot rosterSpot,
			IPositionsByIdsDataLoader positions,
			CancellationToken cancellationToken)
		{
			return await positions.LoadRequiredAsync(rosterSpot.PositionId, cancellationToken);
		}

		public async Task<IEnumerable<AccumulatedStat>> GetAccumulatedStats(
			[Parent] MatchupRosterSpot rosterSpot,
			IAccumulatedStatsByMatchupRosterSpotIdsDataLoader accumulatedStats,
			CancellationToken cancellationToken)
		{
			return await accumulatedStats.LoadAsync(rosterSpot.Id, cancellationToken) ?? [];
		}
		
		public static async Task<MatchupRosterSpot?> GetMatchupRosterSpotAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetMatchupRosterSpotByIdQuery(id), cancellationToken);
		}
    }
}
