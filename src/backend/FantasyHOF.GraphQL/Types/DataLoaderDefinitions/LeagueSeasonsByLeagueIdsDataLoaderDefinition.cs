using FantasyHOF.Application.Queries;
using FantasyHOF.Application.Queries.LeagueSeasons;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
