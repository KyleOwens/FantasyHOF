
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.SportQueries
{
	public sealed record GetSportsByIdsQuery(IEnumerable<SportId> SportIds)
		: IRequest<IEnumerable<Sport>>
	{
		public sealed class GetSportsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetSportsByIdsQuery, IEnumerable<Sport>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<Sport>> Handle(
				GetSportsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.Sports
					.Where(sport => request.SportIds.Contains(sport.Id));
			}
		}
	}
}