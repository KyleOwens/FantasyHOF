using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.Types.Exceptions;
using FantasyHOF.Application.Types.Mutations;
using FantasyHOF.Domain.Entities;
using FantasyHOF.ESPN.Errors;
using FantasyHOF.ESPN.Types.Inputs;
using HotChocolate.Authorization;
using MediatR;

namespace FantasyHOF.GraphQL.Types.Roots
{
    [MutationType]
    public static class Mutation
    {
        [Error(typeof(ESPNAuthenticationException))]
        [Error(typeof(ESPNHttpException))]
        [Error(typeof(ESPNLeagueInvalidException))]
        [Error(typeof(ESPNNoActiveYearsException))]
        [Error(typeof(ESPNInvalidYearException))]
        [Authorize]
        public static async Task<AddLeagueMutationPayload> AddESPNLeagueToUserAsync(
            string leagueId,
            string swid,
            string espnS2Id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(
                new AddESPNLeagueForUserCommand(
                    new ESPNLeagueCredentials(
                        leagueId,
                        swid,
                        espnS2Id)),
                cancellationToken);
        }

        [Error<NotFoundException>]
        [Error<ForbiddenException>]
        [Authorize]
        public static async Task<DeleteUserLeagueMutationPayload> DeleteUserLeagueAsync(
            [ID<League>] int leagueId,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new DeleteUserLeagueMutation(leagueId), cancellationToken);
        }
    }
}
