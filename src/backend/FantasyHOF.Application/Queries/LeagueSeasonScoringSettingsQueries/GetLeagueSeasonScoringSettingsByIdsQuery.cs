
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries
{
	public sealed record GetLeagueSeasonScoringSettingsByIdsQuery(IEnumerable<int> LeagueSeasonScoringSettingsIds)
		: IRequest<IEnumerable<LeagueSeasonScoringSettings>>
	{
		public sealed class GetLeagueSeasonScoringSettingsByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueSeasonScoringSettingsByIdsQuery, IEnumerable<LeagueSeasonScoringSettings>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueSeasonScoringSettings>> Handle(
				GetLeagueSeasonScoringSettingsByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.LeagueSeasonScoringSettings
					.Where(settings => request.LeagueSeasonScoringSettingsIds.Contains(settings.Id));
			}
		}
	}
}
