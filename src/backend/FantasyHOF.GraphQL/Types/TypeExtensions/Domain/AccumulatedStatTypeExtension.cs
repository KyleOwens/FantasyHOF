using FantasyHOF.Application.Queries.AccumulatedStatQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using HotChocolate.Authorization;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [Authorize]
    [ExtendObjectType<AccumulatedStat>]
    internal class AccumulatedStatTypeExtension
    {
        [ID<MatchupRosterSpot>]
        public int MatchupRosterSpotId([Parent] AccumulatedStat stat) => stat.MatchupRosterSpotId;

        [ID<Stat>]
        public int StatId([Parent] AccumulatedStat stat) => (int)stat.StatId;

        public async Task<Stat> GetStatAsync(
            [Parent] AccumulatedStat stat,
            IStatsByStatIdsDataLoader stats,
            CancellationToken cancellationToken)
        {
            return await stats.LoadRequiredAsync(stat.StatId, cancellationToken);
        }


        public static async Task<AccumulatedStat?> GetAccumulatedStatAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetAccumulatedStatByIdQuery(id), cancellationToken);
        }
    }
}
