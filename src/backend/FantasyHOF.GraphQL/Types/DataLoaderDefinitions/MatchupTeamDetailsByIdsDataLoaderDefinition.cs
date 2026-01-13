
using FantasyHOF.Application.Queries.MatchupTeamDetailsQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class MatchupTeamDetailsByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<int, MatchupTeamDetails>> GetMatchupTeamDetailsByIdsAsync(
			IReadOnlyList<int> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var items = await mediator.Send(
				new GetMatchupTeamDetailsByIdsQuery(ids),
				cancellationToken);

			return items.ToDictionary(item => item.Id);
		}
	}
}