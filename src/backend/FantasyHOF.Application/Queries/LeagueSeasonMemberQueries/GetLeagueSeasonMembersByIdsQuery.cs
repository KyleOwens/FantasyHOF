
using FantasyHOF.Domain.Types;
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
	public sealed record GetLeagueSeasonMembersByIdsQuery(IEnumerable<LeagueSeasonMemberId> LeagueSeasonMemberIds)
		: IRequest<IEnumerable<LeagueSeasonMember>>
	{
		public sealed class GetLeagueSeasonMembersByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueSeasonMembersByIdsQuery, IEnumerable<LeagueSeasonMember>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueSeasonMember>> Handle(
				GetLeagueSeasonMembersByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.LeagueSeasonMembers
					.Where(seasonMember => request.LeagueSeasonMemberIds
						.Any(id => id.LeagueSeasonId == seasonMember.LeagueSeasonId && id.MemberId == seasonMember.MemberId));
			}
		}
	}
}
