using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Queries.FantasyProviderQueries;
using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.Queries.UserQueries;
using FantasyHOF.Application.Types.Queries.Records;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using HotChocolate.Authorization;
using MediatR;
using System.Security.Claims;

namespace FantasyHOF.GraphQL.Types.Roots;

[QueryType]
public static class Query
{
    [Authorize]
    public static async Task<User> GetMeAsync(
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetAuthenticatedUserQuery(), cancellationToken);
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

    public static async Task<IEnumerable<FantasyProvider>> GetFantasyProvidersAsync(
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        return await mediator.Send(new GetAllFantasyProvidersQuery(), cancellationToken);
    }

    public static async Task<IEnumerable<RecordMetadata>> GetRecordMetadataAsync()
    {
        return Enum.GetValues(typeof(RecordTypeId))
                    .Cast<RecordTypeId>()
                    .Select(type => new RecordMetadata(type));
    }
}
