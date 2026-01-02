using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.Queries;
using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.Queries.TestQueries;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Outputs;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using FantasyHOF.Infrastructure.Authentication;
using HotChocolate.Authorization;
using MediatR;
using System.Security.Claims;

namespace FantasyHOF.GraphQL.Types.Roots;

[QueryType]
public static class Query
{
    public static async Task<IEnumerable<League>> GetDemoLeaguesAsync(
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetDemoLeaguesQuery(), cancellationToken);
    }
    
    public static async Task<League> GetLeagueAsync(
        [ID<League>] int id, 
        ClaimsPrincipal claimsPrincipal,
        ILeaguesByIdsDataLoader leagues, 
        CancellationToken cancellationToken)
    {
        return await leagues.LoadRequiredAsync(id, cancellationToken);
    }

    // TEST
    public static async Task<LeagueRecordSummary?> GetLeagueRecordsAsync(
        [ID<League>] int leagueId,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetLeagueRecordsQuery(leagueId), cancellationToken);
    }
}
