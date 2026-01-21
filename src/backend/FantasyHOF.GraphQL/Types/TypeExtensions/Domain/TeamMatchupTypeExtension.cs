using FantasyHOF.Application.Queries.TeamMatchupQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<TeamMatchup>]
    internal class TeamMatchupTypeExtension
    {
        [ID<Team>]
        public int TeamId([Parent] TeamMatchup teamMatchup) => teamMatchup.TeamId;

        [ID<MatchupTeamDetails>]
        public int? OwnerMatchupDetailsId([Parent] TeamMatchup teamMatchup) => teamMatchup.OwnerMatchupDetailsId;

        [ID<MatchupTeamDetails>]
        public int? OpponentMatchupDetailsId([Parent] TeamMatchup teamMatchup) => teamMatchup.OpponentMatchupDetailsId;

        [ID<MatchupType>]
        public int MatchupTypeId([Parent] TeamMatchup teamMatchup) => (int)teamMatchup.MatchupTypeId;

        public async Task<MatchupType> GetMatchupTypeAsync(
            [Parent] TeamMatchup teamMatchup,
            IMatchupTypesByIdsDataLoader types,
            CancellationToken cancellationToken)
        {
            return await types.LoadRequiredAsync(teamMatchup.MatchupTypeId, cancellationToken);
        }

        public async Task<MatchupTeamDetails> GetOwnerMatchupDetailsAsync(
            [Parent] TeamMatchup matchup,
            IMatchupTeamDetailsByIdsDataLoader teamDetails,
            CancellationToken cancellationToken)
        {
            return await teamDetails.LoadRequiredAsync(matchup.OwnerMatchupDetailsId, cancellationToken);
        }

        public async Task<MatchupTeamDetails?> GetOpponentMatchupDetailsAsync(
            [Parent] TeamMatchup matchup,
            IMatchupTeamDetailsByIdsDataLoader teamDetails,
            CancellationToken cancellationToken)
        {
            if (matchup.OpponentMatchupDetailsId is null) return null;

            return await teamDetails.LoadRequiredAsync(matchup.OpponentMatchupDetailsId.Value, cancellationToken);
        }

        public static async Task<TeamMatchup?> GetTeamMatchupAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetTeamMatchupByIdQuery(id), cancellationToken);
        }
    }
}
