using FantasyHOF.Application.Queries.LeagueMemberQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal class LeagueMembersByLeagueIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<LeagueMember>>> LeagueMembersByLeagueIdsAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var leagueMembers = await mediator.Send(
                new GetLeagueMembersByLeagueIdsQuery(ids),
                cancellationToken);

            return leagueMembers.GroupBy(leagueMember => leagueMember.LeagueId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}
