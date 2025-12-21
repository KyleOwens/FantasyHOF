
using FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
	internal static class LeagueSeasonScoringSettingByLeagueSeasonIdsDataLoaderDefinition
    {
		[DataLoader]
		public static async Task<Dictionary<int, LeagueSeasonScoringSettings>> GetLeagueSeasonScoringSettingsByLeagueSeasonIdsAsync(
			IReadOnlyList<int> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var settings = await mediator.Send(
				new GetLeagueSeasonScoringSettingsByLeagueSeasonIdsQuery(ids),
				cancellationToken);

			return settings.ToDictionary(setting => setting.LeagueSeasonId);
		}
	}
}