
using FantasyHOF.Application.Queries.MatchupRosterSpotQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
    internal class MatchupRosterSpotsByTeamMatchupIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<MatchupRosterSpot>>> MatchupRosterSpotsByTeamMatchupIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var rosterSpots = await mediator.Send(
                new GetMatchupRosterSpotsByTeamMatchupIdsQuery(ids),
                cancellationToken);

            return rosterSpots.GroupBy(rosterSpot => rosterSpot.MatchupId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}