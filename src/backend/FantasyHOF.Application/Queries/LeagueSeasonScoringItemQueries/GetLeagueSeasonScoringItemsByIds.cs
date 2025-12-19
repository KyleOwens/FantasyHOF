using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries
{
	public sealed record GetLeagueSeasonScoringItemsByIdsQuery(IEnumerable<int> LeagueSeasonScoringItemIds)
		: IRequest<IEnumerable<LeagueSeasonScoringItem>>
	{
		public sealed class GetLeagueSeasonScoringItemsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueSeasonScoringItemsByIdsQuery, IEnumerable<LeagueSeasonScoringItem>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueSeasonScoringItem>> Handle(
				GetLeagueSeasonScoringItemsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.LeagueSeasonScoringItems
					.Where(item => request.LeagueSeasonScoringItemIds.Contains(item.Id));
			}
		}
	}
}
