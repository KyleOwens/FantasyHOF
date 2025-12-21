
using FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
	internal static class LeagueSeasonScheduleSettingsByLeagueSeasonIdsDataLoaderDefinition
	{	
		[DataLoader]
		public static async Task<Dictionary<int, LeagueSeasonScheduleSettings>> GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsAsync(
			IReadOnlyList<int> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var settings = await mediator.Send(
				new GetLeagueSeasonScheduleSettingsByLeagueSeasonIdsQuery(ids),
				cancellationToken);

			return settings.ToDictionary(setting => setting.LeagueSeasonId);
		}
	}
}
