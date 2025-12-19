using FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
	[ExtendObjectType(typeof(LeagueSeasonScoringItem))]
    internal class LeagueSeasonScoringItemTypeExtension
	{
        [ID(nameof(LeagueSeason))]
        public int LeagueSeasonId([Parent] LeagueSeasonScoringItem scoringItem) => scoringItem.LeagueSeasonId;

        [ID(nameof(Stat))]
        public int StatId([Parent] LeagueSeasonScoringItem scoringItem) => (int)scoringItem.StatId;

        public async Task<Stat> GetStatAsync(
            [Parent] LeagueSeasonScoringItem scoringItem,
            IStatsByStatIdsDataLoader stats,
            CancellationToken cancellationToken)
        {
            return await stats.LoadRequiredAsync(scoringItem.StatId, cancellationToken);
        }

        public static async Task<LeagueSeasonScoringItem?> GetLeagueSeasonScoringItemAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetLeagueSeasonScoringItemByIdQuery(id), cancellationToken);
		}
    }
}
