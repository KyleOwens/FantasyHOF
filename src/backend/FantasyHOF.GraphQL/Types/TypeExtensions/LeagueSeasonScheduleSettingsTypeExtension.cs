using FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType(typeof(LeagueSeasonScheduleSettings))]
    internal class LeagueSeasonScheduleSettingsTypeExtension
	{
        [ID<LeagueSeason>]
        public int LeagueSeasonId([Parent] LeagueSeasonScheduleSettings leagueSeasonScheduleSettings) => leagueSeasonScheduleSettings.LeagueSeasonId;

        public static async Task<LeagueSeasonScheduleSettings?> GetLeagueSeasonScheduleSettingsAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetLeagueSeasonScheduleSettingsByIdQuery(id), cancellationToken);
		}
    }
}
