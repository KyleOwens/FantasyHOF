using FantasyHOF.Application.Queries.TeamQueries;
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
    [ExtendObjectType<Team>]
    internal class TeamTypeExtension
	{
		public async Task<TeamSeasonStats> GetSeasonStats(
			[Parent] Team team,
			ITeamSeasonStatsByTeamIdsDataLoader stats,
			CancellationToken cancellationToken)
		{
			return await stats.LoadRequiredAsync(team.Id, cancellationToken);
		}

		public async Task<IEnumerable<TeamMatchup>> GetMatchups(
			[Parent] Team team,
			ITeamMatchupsByTeamIdsDataLoader matchups,
			CancellationToken cancellationToken)
		{
			return await matchups.LoadAsync(team.Id, cancellationToken) ?? [];
        }

        public static async Task<Team?> GetTeamAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetTeamByIdQuery(id), cancellationToken);
		}
    }
}
