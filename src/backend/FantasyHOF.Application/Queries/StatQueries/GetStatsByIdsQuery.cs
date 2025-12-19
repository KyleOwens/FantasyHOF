
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.StatQueries
{
	public sealed record GetStatsByIdsQuery(IEnumerable<StatId> StatIds)
		: IRequest<IEnumerable<Stat>>
	{
		public sealed class GetStatsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetStatsByIdsQuery, IEnumerable<Stat>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<Stat>> Handle(
				GetStatsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.Stats
					.Where(stat => request.StatIds.Contains(stat.Id));
			}
		}
	}
}
