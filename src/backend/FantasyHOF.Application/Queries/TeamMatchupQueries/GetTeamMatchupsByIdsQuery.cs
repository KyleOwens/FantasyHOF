
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

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
				return _context.TeamMatchups
					.Where(matchup => request.TeamMatchupIds.Contains(matchup.Id));
			}
		}
	}
}