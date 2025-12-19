using FantasyHOF.Application.Queries.LeagueSeasons;
using FantasyHOF.Domain.Types;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{        
    [Node]
    [ExtendObjectType(typeof(LeagueSeason))]
    public class LeagueSeasonTypeExtension
    {
        [ID(nameof(League))]
        public int LeagueId([Parent] LeagueSeason season) => season.LeagueId;

        public async Task<LeagueSeasonSettings> GetSettingsAsync(
            [Parent] LeagueSeason season, 
            ILeagueSeasonSettingsByLeagueSeasonIdsDataLoader leagueSeasonSettings, 
            CancellationToken cancellationToken)
        {
            return await leagueSeasonSettings.LoadRequiredAsync(season.Id, cancellationToken);
        }
        
        public static async Task<LeagueSeason?> GetLeagueSeasonAsync(
            int id, 
            IMediator mediator, 
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueSeasonByIdQuery(id), cancellationToken);
        }
    }
}
