
using FantasyHOF.Application.Queries.FantasyProviderQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class FantasyProviderByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<FantasyProviderId, FantasyProvider>> GetFantasyProvidersByIdsAsync(
			IReadOnlyList<FantasyProviderId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var providers = await mediator.Send(
				new GetFantasyProvidersByIdsQuery(ids),
				cancellationToken);

			return providers.ToDictionary(provider => provider.Id);
		}
	}
}