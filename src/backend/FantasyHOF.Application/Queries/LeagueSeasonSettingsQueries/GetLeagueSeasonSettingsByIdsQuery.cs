using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries
{
	public sealed record GetLeagueSeasonSettingsByIdsQuery(IEnumerable<int> LeagueSeasonSettingsIds)
		: IRequest<IEnumerable<LeagueSeasonSettings>>
	{
		public sealed class GetLeagueSeasonSettingsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueSeasonSettingsByIdsQuery, IEnumerable<LeagueSeasonSettings>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueSeasonSettings>> Handle(
                GetLeagueSeasonSettingsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.LeagueSeasonSettings
					.AsNoTracking()
					.Where(settings => request.LeagueSeasonSettingsIds.Contains(settings.Id))
                    .ToListAsync();
			}
		}
	}
}
