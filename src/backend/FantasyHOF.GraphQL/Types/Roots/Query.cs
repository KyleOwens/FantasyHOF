using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.Queries;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Outputs;
using MediatR;

namespace FantasyHOF.GraphQL.Types.Roots;

[QueryType]
public static class Query
{
    public static async Task<League?> GetLeague([ID] int id, [Service] IMediator mediator)
    {
        return await mediator.Send(new LoadLeagueQuery(id));
    }
}
