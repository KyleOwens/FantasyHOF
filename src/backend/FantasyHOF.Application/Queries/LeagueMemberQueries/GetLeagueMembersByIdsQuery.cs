using FantasyHOF.EntityFramework;
using MediatR;
using FantasyHOF.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Application.Queries.LeagueMemberQueries
{
	public sealed record GetLeagueMembersByIdsQuery(IEnumerable<LeagueMemberId> LeagueMemberIds)
		: IRequest<IEnumerable<LeagueMember>>
	{
		public sealed class GetLeagueMembersByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueMembersByIdsQuery, IEnumerable<LeagueMember>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueMember>> Handle(
				GetLeagueMembersByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.LeagueMembers
					.AsNoTracking()
					.Where(leagueMember => request.LeagueMemberIds
						.Any(id => id.LeagueId == leagueMember.LeagueId && id.MemberId == leagueMember.MemberId))
					.ToListAsync(cancellationToken);
			}
		}
	}
}