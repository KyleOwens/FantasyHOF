
using FantasyHOF.Application.Queries.SportQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class SportsByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<SportId, Sport>> GetSportsByIdsAsync(
			IReadOnlyList<SportId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var sports = await mediator.Send(
				new GetSportsByIdsQuery(ids),
				cancellationToken);

			return sports.ToDictionary(sport => sport.Id);
		}
	}
}