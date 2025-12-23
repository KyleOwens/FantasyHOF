
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.PositionQueries
{
	public sealed record GetPositionsByIdsQuery(IEnumerable<PositionId> PositionIds)
		: IRequest<IEnumerable<Position>>
	{
		public sealed class GetPositionsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetPositionsByIdsQuery, IEnumerable<Position>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<Position>> Handle(
				GetPositionsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.Positions
					.Where(position => request.PositionIds.Contains(position.Id))
                    .ToListAsync();
			}
		}
	}
}