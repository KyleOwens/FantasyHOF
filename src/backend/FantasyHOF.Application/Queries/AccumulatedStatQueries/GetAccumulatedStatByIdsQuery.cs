
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.AccumulatedStatQueries
{
	public sealed record GetAccumulatedStatsByIdsQuery(IEnumerable<int> AccumulatedStatIds)
		: IRequest<IEnumerable<AccumulatedStat>>
	{
		public sealed class GetAccumulatedStatsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetAccumulatedStatsByIdsQuery, IEnumerable<AccumulatedStat>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<AccumulatedStat>> Handle(
				GetAccumulatedStatsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.AccumulatedStats
					.Where(stat => request.AccumulatedStatIds.Contains(stat.Id))
					.ToListAsync();
			}
		}
	}
}