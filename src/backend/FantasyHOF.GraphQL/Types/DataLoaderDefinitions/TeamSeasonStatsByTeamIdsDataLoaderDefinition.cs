
using FantasyHOF.Application.Queries.TeamSeasonStatsQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class TeamSeasonStatsByTeamIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<int, TeamSeasonStats>> GetTeamSeasonStatsByTeamIdsAsync(
			IReadOnlyList<int> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var stats = await mediator.Send(
				new GetTeamSeasonStatsByTeamIdsQuery(ids),
				cancellationToken);

			return stats.ToDictionary(stat => stat.TeamId);
		}
	}
}