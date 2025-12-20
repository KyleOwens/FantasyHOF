using FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries;
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
	[ExtendObjectType(typeof(LeagueSeasonScoringSettings))]
    internal class LeagueSeasonScoringSettingsTypeExtension
	{
        [ID<LeagueSeason>]
        public int LeagueSeasonId([Parent] LeagueSeasonScoringSettings leagueSeasonScoringSettings) => leagueSeasonScoringSettings.LeagueSeasonId;

        public async Task<IEnumerable<LeagueSeasonScoringItem>> GetScoringItemsAsync(
			[Parent] LeagueSeasonScoringSettings leagueSeasonScoringSettings,
			ILeagueSeasonScoringItemsByLeagueSeasonIdsDataLoader scoringItems,
			CancellationToken cancellationToken)
		{
			return await scoringItems.LoadAsync(leagueSeasonScoringSettings.LeagueSeasonId, cancellationToken) ?? [];
        }

        public static async Task<LeagueSeasonScoringSettings?> GetLeagueSeasonScoringSettingsAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetLeagueSeasonScoringSettingsByIdQuery(id), cancellationToken);
		}
    }
}
