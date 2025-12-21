
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamSeasonStatsQueries
{
	public sealed record GetTeamSeasonStatsByIdsQuery(IEnumerable<int> TeamSeasonStatsIds)
		: IRequest<IEnumerable<TeamSeasonStats>>
	{
		public sealed class GetTeamSeasonStatsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetTeamSeasonStatsByIdsQuery, IEnumerable<TeamSeasonStats>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<TeamSeasonStats>> Handle(
				GetTeamSeasonStatsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.TeamSeasonStats
					.Where(stats => request.TeamSeasonStatsIds.Contains(stats.Id));
			}
		}
	}
}