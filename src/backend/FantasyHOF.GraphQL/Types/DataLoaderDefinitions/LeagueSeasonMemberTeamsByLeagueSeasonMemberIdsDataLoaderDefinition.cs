
using FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries;
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class LeagueSeasonMemberTeamByLeagueSeasonMemberIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<LeagueSeasonMemberId, List<LeagueSeasonMemberTeam>>> GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsAsync(
			IReadOnlyList<LeagueSeasonMemberId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var memberTeams = await mediator.Send(
				new GetLeagueSeasonMemberTeamsByLeagueSeasonMemberIdsQuery(ids),
				cancellationToken);

			return memberTeams
				.GroupBy(memberTeam => new LeagueSeasonMemberId
				{
					LeagueSeasonId = memberTeam.Id.LeagueSeasonId,
					MemberId = memberTeam.Id.MemberId
				})
				.Select(group => new { group.Key, Items = group.ToList() })
                .ToDictionary(entry => entry.Key, entry => entry.Items);
		}
	}
}
