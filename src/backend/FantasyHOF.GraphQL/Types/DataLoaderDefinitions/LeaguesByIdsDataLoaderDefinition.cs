using FantasyHOF.Application.Queries.Leagues;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal static class LeaguesByIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, League>> GetLeaguesByIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var leagues = await mediator.Send(
                new GetLeaguesByIdsQuery(ids),
                cancellationToken);

            return leagues.ToDictionary(league => league.Id);
        }
    }
}
