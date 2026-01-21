using FantasyHOF.Application.Queries.TeamSeasonStatsQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<TeamSeasonStats>]
    internal class TeamSeasonStatsTypeExtension
    {
        [ID<Team>]
        public int TeamId([Parent] TeamSeasonStats stats) => stats.TeamId;

        public static async Task<TeamSeasonStats?> GetTeamSeasonStatsAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetTeamSeasonStatsByIdQuery(id), cancellationToken);
        }
    }
}
