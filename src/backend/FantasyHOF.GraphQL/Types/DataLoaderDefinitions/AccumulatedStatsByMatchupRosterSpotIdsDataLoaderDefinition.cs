
using FantasyHOF.Application.Queries.AccumulatedStatQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
    internal class AccumulatedStatsByMatchupRosterSpotIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<AccumulatedStat>>> AccumulatedStatsByMatchupRosterSpotIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var accumulatedStats = await mediator.Send(
                new GetAccumulatedStatsByMatchupRosterSpotIdsQuery(ids),
                cancellationToken);

            return accumulatedStats.GroupBy(stat => stat.MatchupRosterSpotId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}