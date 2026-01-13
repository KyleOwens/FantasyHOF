
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries
{
	public sealed record GetLeagueSeasonMemberTeamsByIdsQuery(IEnumerable<LeagueSeasonMemberTeamId> LeagueSeasonMemberTeamIds)
		: IRequest<IEnumerable<LeagueSeasonMemberTeam>>
	{
		public sealed class GetLeagueSeasonMemberTeamsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueSeasonMemberTeamsByIdsQuery, IEnumerable<LeagueSeasonMemberTeam>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueSeasonMemberTeam>> Handle(
				GetLeagueSeasonMemberTeamsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.LeagueSeasonMemberTeams
					.AsNoTracking()
					.Where(memberTeam => request.LeagueSeasonMemberTeamIds
						.Any(id => id.LeagueSeasonId == memberTeam.LeagueSeasonId &&
									id.MemberId == memberTeam.MemberId &&
									id.TeamId == memberTeam.TeamId))
                    .ToListAsync(cancellationToken);
			}
		}
	}
}
