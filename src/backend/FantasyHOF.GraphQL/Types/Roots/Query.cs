using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.Queries;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Outputs;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using MediatR;

namespace FantasyHOF.GraphQL.Types.Roots;

[QueryType]
public static class Query
{
    public static async Task<League> GetLeagueAsync(
        [ID(nameof(League))] int id, 
        ILeaguesByIdsDataLoader leagues, 
        CancellationToken cancellationToken)
    {
        return await leagues.LoadRequiredAsync(id, cancellationToken);
    }
}
