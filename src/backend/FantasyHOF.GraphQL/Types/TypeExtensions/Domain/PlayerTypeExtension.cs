using FantasyHOF.Application.Queries.PlayerQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<Player>]
    internal class PlayerTypeExtension
    {
        [ID<FantasyProvider>]
        public int ProviderId([Parent] Player player) => (int)player.ProviderId;

        public string PlayerImageURL(
            [Parent] Player player,
            int width = 96,
            int height = 70)
        {
            return player.PlayerImageURL(width, height);
        }

        public async Task<FantasyProvider> GetProviderAsync(
            [Parent] Player player,
            IFantasyProvidersByIdsDataLoader providers,
            CancellationToken cancellationToken)
        {
            return await providers.LoadRequiredAsync(player.ProviderId, cancellationToken);
        }

        public static async Task<Player?> GetPlayerAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetPlayerByIdQuery(id), cancellationToken);
        }
    }
}
