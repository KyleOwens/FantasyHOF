
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamQueries
{
	public sealed record GetTeamsByIdsQuery(IEnumerable<int> TeamIds)
		: IRequest<IEnumerable<Team>>
	{
		public sealed class GetTeamsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetTeamsByIdsQuery, IEnumerable<Team>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<Team>> Handle(
				GetTeamsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.Teams
					.Where(team => request.TeamIds.Contains(team.Id));
			}
		}
	}
}
