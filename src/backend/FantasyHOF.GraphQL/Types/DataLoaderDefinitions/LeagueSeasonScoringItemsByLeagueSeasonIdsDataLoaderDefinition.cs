
using FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal class LeagueSeasonScoringItemsByLeagueSeasonIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<LeagueSeasonScoringItem>>> LeagueSeasonScoringItemsByLeagueSeasonIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var scoringItems = await mediator.Send(
                new GetLeagueSeasonScoringItemsByLeagueSeasonIdsQuery(ids),
                cancellationToken);

            return scoringItems.GroupBy(scoringItem => scoringItem.LeagueSeasonId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}
