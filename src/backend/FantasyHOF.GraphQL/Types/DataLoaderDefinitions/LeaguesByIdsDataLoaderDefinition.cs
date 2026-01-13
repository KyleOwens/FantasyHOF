using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal static class LeaguesByIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, League>> GetLeaguesByIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var leagues = await mediator.Send(
                new GetLeaguesByIdsQuery(ids),
                cancellationToken);

            return leagues.ToDictionary(league => league.Id);
        }
    }
}
