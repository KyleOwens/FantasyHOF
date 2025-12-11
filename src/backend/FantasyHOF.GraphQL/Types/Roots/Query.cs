using FantasyHOF.Application.Queries;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Outputs;
using FantasyHOF.GraphQL.Types.Extensions;
using FantasyHOF.GraphQL.Types.Inputs;
using MediatR;

namespace FantasyHOF.GraphQL.Types.Roots;

[QueryType]
public static class Query
{
    public static async Task<List<ESPNWeeklyLeagueData>> LoadESPNLeague(ESPNLeagueCredentialsInput input, IMediator mediator)
    {
        return await mediator.Send(new GetESPNLeagueQuery(new ESPNLeagueCredentials(input.LeagueId, input.SWID, input.ESPNS2Id)));
    }
}
