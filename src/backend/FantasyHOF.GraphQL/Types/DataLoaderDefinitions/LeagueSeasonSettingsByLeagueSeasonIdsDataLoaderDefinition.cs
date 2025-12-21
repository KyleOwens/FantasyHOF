using FantasyHOF.Application.Queries;
using FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal static class LeagueSeasonSettingsByLeagueSeasonIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, LeagueSeasonSettings>> GetLeagueSeasonSettingsByLeagueSeasonIdsAsync(
            IReadOnlyList<int> leagueSeasonIds,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            IEnumerable<LeagueSeasonSettings> settings = await mediator.Send(
                new GetLeagueSeasonSettingsByLeagueSeasonIdsQuery(leagueSeasonIds),
                cancellationToken);

            return settings.ToDictionary(settings => settings.LeagueSeasonId);
        }
    }
}
