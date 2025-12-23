
using FantasyHOF.Application.Queries.TeamMatchupQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
    internal class TeamMatchupsByTeamIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<TeamMatchup>>> TeamMatchupsByTeamIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var matchups = await mediator.Send(
                new GetTeamMatchupsByTeamIdsQuery(ids),
                cancellationToken);

            return matchups.GroupBy(matchup => matchup.TeamId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}