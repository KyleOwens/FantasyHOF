
using FantasyHOF.Application.Queries.MatchupTypeQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class MatchupTypesByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<MatchupTypeId, MatchupType>> GetMatchupTypesByIdsAsync(
			IReadOnlyList<MatchupTypeId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var types = await mediator.Send(
				new GetMatchupTypesByIdsQuery(ids),
				cancellationToken);

			return types.ToDictionary(type => type.Id);
		}
	}
}