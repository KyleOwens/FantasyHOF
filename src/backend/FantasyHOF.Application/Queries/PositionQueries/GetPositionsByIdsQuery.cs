using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Entities;

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
					.AsNoTracking()
					.Where(position => request.PositionIds.Contains(position.Id))
                    .ToListAsync();
			}
		}
	}
}