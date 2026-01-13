
using FantasyHOF.Application.Queries.MatchupRosterSpotQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
    internal class MatchupRosterSpotsByMatchupTeamDetailsIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<MatchupRosterSpot>>> MatchupRosterSpotsByMatchupTeamDetailsIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var rosterSpots = await mediator.Send(
                new GetMatchupRosterSpotsByMatchupTeamDetailsIdsQuery(ids),
                cancellationToken);

            return rosterSpots.GroupBy(rosterSpot => rosterSpot.MatchupTeamDetailsId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}