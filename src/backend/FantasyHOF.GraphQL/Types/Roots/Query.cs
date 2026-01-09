using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.Queries;
using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.Queries.UserQueries;
using FantasyHOF.Application.QueryTypes.Records;
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
    public static async Task<User> GetMeAsync(
        IMediator mediator, 
        CancellationToken cancellation)
    {
        return await mediator.Send(new GetAuthenticatedUserQuery());
    }
    
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

    public static async Task<IEnumerable<RecordMetadata>> GetRecordMetadataAsync()
    {
        return Enum.GetValues(typeof(RecordTypeId))
                    .Cast<RecordTypeId>()
                    .Select(type => new RecordMetadata(type));
    }
}
