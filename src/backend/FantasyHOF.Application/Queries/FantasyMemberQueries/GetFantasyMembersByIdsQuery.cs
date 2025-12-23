
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.FantasyMemberQueries
{
	public sealed record GetFantasyMembersByIdsQuery(IEnumerable<int> FantasyMemberIds)
		: IRequest<IEnumerable<FantasyMember>>
	{
		public sealed class GetFantasyMembersByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetFantasyMembersByIdsQuery, IEnumerable<FantasyMember>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<FantasyMember>> Handle(
				GetFantasyMembersByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.FantasyMembers
					.Where(member => request.FantasyMemberIds.Contains(member.Id))
					.ToListAsync();
			}
		}
	}
}