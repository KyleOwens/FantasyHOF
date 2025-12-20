using FantasyHOF.Application.Queries.LeagueSeasonMemberQueries;
using FantasyHOF.Domain.Types;
using FantasyHOF.Domain.ComplexIds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		public int leagueSeasonId([Parent] LeagueSeasonMember member) => member.LeagueSeasonId;

        public static async Task<LeagueSeasonMember?> GetLeagueSeasonMemberAsync(
			string id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetLeagueSeasonMemberByIdQuery(LeagueSeasonMemberId.Parse(id)), cancellationToken);
		}
    }
}
