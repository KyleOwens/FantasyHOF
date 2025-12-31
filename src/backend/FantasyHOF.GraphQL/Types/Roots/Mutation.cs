using FantasyHOF.Application.Mutations;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN.Errors;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.Infrastructure.Authentication;
using HotChocolate.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

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
        public static async Task<League> AddESPNLeagueToUserAsync(
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
    }
}
