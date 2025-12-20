
using FantasyHOF.Application.Queries.LeagueSeasonMemberQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
    internal class LeagueSeasonMemberByLeagueSeasonIdDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<int, List<LeagueSeasonMember>>> LeagueSeasonMembersByLeagueSeasonIdAsync(
            IReadOnlyList<int> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var seasonMembers = await mediator.Send(
                new GetLeagueSeasonMembersByLeagueSeasonIdsQuery(ids),
                cancellationToken);

            return seasonMembers.GroupBy(member => member.LeagueSeasonId)
                .Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
        }
    }
}
