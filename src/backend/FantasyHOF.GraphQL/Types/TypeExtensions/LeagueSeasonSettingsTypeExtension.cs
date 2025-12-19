using FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries;
using FantasyHOF.Application.Queries.LeagueSeasonSettingss;
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
	[ExtendObjectType(typeof(LeagueSeasonSettings))]
	internal class LeagueSeasonSettingsTypeExtension
	{
		[ID(nameof(LeagueSeason))]
		public int LeagueSeasonId([Parent] LeagueSeasonSettings settings) => settings.LeagueSeasonId;

		public async Task<LeagueSeasonScheduleSettings> GetScheduleSettings(
			[Parent] LeagueSeasonSettings settings,
			ILeagueSeasonScheduleSettingsByLeagueSeasonIdsDataLoader scheduleSettings,
			CancellationToken cancellationToken)
		{
			return await scheduleSettings.LoadRequiredAsync(settings.LeagueSeasonId, cancellationToken);
		}

		public async Task<LeagueSeasonScoringSettings> GetScoringSettings(
			[Parent] LeagueSeasonSettings settings,
			ILeagueSeasonScoringSettingsByLeagueSeasonIdsDataLoader scoringSettings,
			CancellationToken cancellationToken)
		{
			return await scoringSettings.LoadRequiredAsync(settings.Id, cancellationToken);
		}

		public static async Task<LeagueSeasonSettings?> GetLeagueSeasonSettingsAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetLeagueSeasonSettingsByIdQuery(id), cancellationToken);
		}
	}
}
