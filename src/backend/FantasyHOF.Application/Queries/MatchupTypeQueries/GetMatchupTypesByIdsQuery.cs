
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupTypeQueries
{
	public sealed record GetMatchupTypesByIdsQuery(IEnumerable<MatchupTypeId> MatchupTypeIds)
		: IRequest<IEnumerable<MatchupType>>
	{
		public sealed class GetMatchupTypesByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetMatchupTypesByIdsQuery, IEnumerable<MatchupType>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<MatchupType>> Handle(
				GetMatchupTypesByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.MatchupTypes
					.Where(type => request.MatchupTypeIds.Contains(type.Id))
                    .ToListAsync();
			}
		}
	}
}