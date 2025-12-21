using FantasyHOF.Application.Queries.TeamSeasonStatsQueries;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<TeamSeasonStats>]
    internal class TeamSeasonStatsTypeExtension
	{
		[ID<Team>]
		public int TeamId([Parent] TeamSeasonStats stats) => stats.TeamId;

        public static async Task<TeamSeasonStats?> GetTeamSeasonStatsAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetTeamSeasonStatsByIdQuery(id), cancellationToken);
		}
    }
}
