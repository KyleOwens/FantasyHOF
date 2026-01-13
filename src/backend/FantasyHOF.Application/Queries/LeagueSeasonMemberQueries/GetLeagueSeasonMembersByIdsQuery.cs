
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.ComplexIds;

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
				return await _context.LeagueSeasonMembers
					.AsNoTracking()
					.Where(seasonMember => request.LeagueSeasonMemberIds
						.Any(id => id.LeagueSeasonId == seasonMember.LeagueSeasonId && id.MemberId == seasonMember.MemberId))
                    .ToListAsync(cancellationToken);
			}
		}
	}
}
