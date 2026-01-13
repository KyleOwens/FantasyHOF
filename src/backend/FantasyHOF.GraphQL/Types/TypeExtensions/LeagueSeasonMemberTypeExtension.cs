using FantasyHOF.Application.Queries.LeagueSeasonMemberQueries;
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType(typeof(LeagueSeasonMember))]
    public class LeagueSeasonMemberTypeExtension
    {
        [ID]
        public string Id([Parent] LeagueSeasonMember member)
            => new LeagueSeasonMemberId(member.LeagueSeasonId, member.MemberId).ToString();

        [ID<LeagueSeason>]
        public int LeagueSeasonId([Parent] LeagueSeasonMember member) => member.LeagueSeasonId;

        [ID<FantasyMember>]
        public int MemberId([Parent] LeagueSeasonMember member) => member.MemberId;

        public async Task<FantasyMember> GetMemberAsync(
            [Parent] LeagueSeasonMember seasonMember,
            IFantasyMembersByIdsDataLoader members,
            CancellationToken cancellationToken)
        {
            return await members.LoadRequiredAsync(seasonMember.MemberId, cancellationToken);
        }

        public async Task<IEnumerable<LeagueSeasonMemberTeam>> GetTeamsAsync(
            [Parent] LeagueSeasonMember seasonMember,
            ILeagueSeasonMemberTeamsByLeagueSeasonMemberIdsDataLoader dataLoader,
            CancellationToken cancellationToken)
        {
            var id = new LeagueSeasonMemberId(seasonMember.LeagueSeasonId, seasonMember.MemberId);

            return await dataLoader.LoadAsync(id, cancellationToken) ?? [];
        }

        public static async Task<LeagueSeasonMember?> GetLeagueSeasonMemberAsync(
            string id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueSeasonMemberByIdQuery(LeagueSeasonMemberId.Parse(id)), cancellationToken);
        }
    }
}
