using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.TeamMatchupQueries
{
	public sealed record GetTeamMatchupsByIdsQuery(IEnumerable<int> TeamMatchupIds)
		: IRequest<IEnumerable<TeamMatchup>>
	{
		public sealed class GetTeamMatchupsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetTeamMatchupsByIdsQuery, IEnumerable<TeamMatchup>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<TeamMatchup>> Handle(
				GetTeamMatchupsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.TeamMatchups
					.AsNoTracking()
					.Where(matchup => request.TeamMatchupIds.Contains(matchup.Id))
					.ToListAsync();
			}
		}
	}
}