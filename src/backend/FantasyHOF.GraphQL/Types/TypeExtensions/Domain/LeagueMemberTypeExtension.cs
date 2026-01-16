using FantasyHOF.Application.Queries.LeagueMemberQueries;
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<LeagueMember>]
    internal class LeagueMemberTypeExtension
    {
        [ID]
        public string Id([Parent] LeagueMember member) => new LeagueMemberId(member.LeagueId, member.MemberId).ToString();

        [ID<League>]
        public int LeagueId([Parent] LeagueMember member) => member.LeagueId;

        [ID<FantasyMember>]
        public int MemberId([Parent] LeagueMember member) => member.MemberId;

        public async Task<League> GetLeagueAsync(
            [Parent] LeagueMember member,
            ILeaguesByIdsDataLoader leagues,
            CancellationToken cancellationToken)
        {
            return await leagues.LoadRequiredAsync(member.LeagueId, cancellationToken);
        }

        public async Task<FantasyMember> GetMemberAsync(
            [Parent] LeagueMember member,
            IFantasyMembersByIdsDataLoader members,
            CancellationToken cancellationToken)
        {
            return await members.LoadRequiredAsync(member.MemberId, cancellationToken);
        }

        public static async Task<LeagueMember?> GetLeagueMemberAsync(
            string id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueMemberByIdQuery(LeagueMemberId.Parse(id)), cancellationToken);
        }
    }
}
