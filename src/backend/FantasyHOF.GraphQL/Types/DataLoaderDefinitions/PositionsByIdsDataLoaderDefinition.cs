
using FantasyHOF.Application.Queries.PositionQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class PositionsByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<PositionId, Position>> GetPositionsByIdsAsync(
			IReadOnlyList<PositionId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var positions = await mediator.Send(
				new GetPositionsByIdsQuery(ids),
				cancellationToken);

			return positions.ToDictionary(position => position.Id);
		}
	}
}