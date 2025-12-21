
using FantasyHOF.Application.Queries.TeamQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class TeamsByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<int, Team>> GetTeamssByIdsAsync(
			IReadOnlyList<int> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var teams = await mediator.Send(
				new GetTeamsByIdsQuery(ids),
				cancellationToken);

			return teams.ToDictionary(team => team.Id);
		}
	}
}

