
using FantasyHOF.Application.Queries.StatQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class StatByStatIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<StatId, Stat>> GetStatsByStatIdsAsync(
			IReadOnlyList<StatId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var stats = await mediator.Send(
				new GetStatsByIdsQuery(ids),
				cancellationToken);

			return stats.ToDictionary(stat => stat.Id);
		}
	}
}
