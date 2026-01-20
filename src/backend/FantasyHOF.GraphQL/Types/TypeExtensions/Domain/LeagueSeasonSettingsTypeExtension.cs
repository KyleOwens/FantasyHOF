using FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using HotChocolate.Authorization;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [Authorize]
    [ExtendObjectType(typeof(LeagueSeasonSettings))]
    internal class LeagueSeasonSettingsTypeExtension
    {
        [ID<LeagueSeason>]
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
