using FantasyHOF.Application.Queries.PlayerQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal static class PlayersByIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, Player>> GetPlayersByIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var players = await mediator.Send(
                new GetPlayersByIdsQuery(ids),
                cancellationToken);

            return players.ToDictionary(player => player.Id);
        }
    }
}