using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using FantasyHOF.GraphQL.Types.Roots;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType(typeof(League))]
    public class LeagueTypeExtension
    {
        public async Task<IEnumerable<LeagueSeason>> GetSeasonsAsync(
            [Parent] League league, 
            ILeagueSeasonsByLeagueIdsDataLoader leagueSeasons, 
            CancellationToken cancellationToken)
        {
            return await leagueSeasons.LoadAsync(league.Id, cancellationToken) ?? [];
        }

        public static async Task<League?> GetLeagueAsync(
            int id,
            ILeaguesByIdsDataLoader leagues,
            CancellationToken cancellationToken)
        {
            return await leagues.LoadAsync(id, cancellationToken);
        }
    }
}
