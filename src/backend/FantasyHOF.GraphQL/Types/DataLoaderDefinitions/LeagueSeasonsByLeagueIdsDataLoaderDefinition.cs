using FantasyHOF.Application.Queries.LeagueSeasonQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal static class LeagueSeasonsByLeagueIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<LeagueSeason>>> GetLeagueSeasonsByLeagueIdsAsync(
            IReadOnlyList<int> leagueSeasonIds,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            IEnumerable<LeagueSeason> seasons = await mediator.Send(
                new GetLeagueSeasonsByLeagueIdsQuery(leagueSeasonIds),
                cancellationToken);

            return seasons.GroupBy(season => season.LeagueId)
                .Select(group => new { group.Key, Items = group.OrderBy(season => season.Year).ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}
