using FantasyHOF.Application.Mutations;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN.Errors;
using FantasyHOF.ESPN.Types.Inputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static async Task<League> LoadESPNLeague(string leagueId, string swid, string espnS2Id, IMediator mediator)
        {
            return await mediator.Send(new LoadESPNLeagueCommand(new ESPNLeagueCredentials(
                leagueId,
                swid,
                espnS2Id)));
        }
    }
}
