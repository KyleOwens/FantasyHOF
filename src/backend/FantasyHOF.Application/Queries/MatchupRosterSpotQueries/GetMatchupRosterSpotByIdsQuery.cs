
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
	public sealed record GetMatchupRosterSpotsByIdsQuery(IEnumerable<int> MatchupRosterSpotIds)
		: IRequest<IEnumerable<MatchupRosterSpot>>
	{
		public sealed class GetMatchupRosterSpotsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetMatchupRosterSpotsByIdsQuery, IEnumerable<MatchupRosterSpot>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<MatchupRosterSpot>> Handle(
				GetMatchupRosterSpotsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.MatchupRosterSpots
					.Where(rosterSpot => request.MatchupRosterSpotIds.Contains(rosterSpot.Id))
                    .ToListAsync();
			}
		}
	}
}