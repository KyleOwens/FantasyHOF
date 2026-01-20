using FantasyHOF.Application.Queries.TeamQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using HotChocolate.Authorization;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [Authorize]
    [ExtendObjectType<Team>]
    internal class TeamTypeExtension
    {
        public async Task<TeamSeasonStats> GetSeasonStats(
            [Parent] Team team,
            ITeamSeasonStatsByTeamIdsDataLoader stats,
            CancellationToken cancellationToken)
        {
            return await stats.LoadRequiredAsync(team.Id, cancellationToken);
        }

        public async Task<IEnumerable<TeamMatchup>> GetMatchups(
            [Parent] Team team,
            ITeamMatchupsByTeamIdsDataLoader matchups,
            CancellationToken cancellationToken)
        {
            return await matchups.LoadAsync(team.Id, cancellationToken) ?? [];
        }

        public static async Task<Team?> GetTeamAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetTeamByIdQuery(id), cancellationToken);
        }
    }
}
