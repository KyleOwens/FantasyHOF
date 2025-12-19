
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries
{
	public sealed record GetLeagueSeasonScheduleSettingssByIdsQuery(IEnumerable<int> LeagueSeasonScheduleSettingsIds)
		: IRequest<IEnumerable<LeagueSeasonScheduleSettings>>
	{
		public sealed class GetLeagueSeasonScheduleSettingssByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetLeagueSeasonScheduleSettingssByIdsQuery, IEnumerable<LeagueSeasonScheduleSettings>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<LeagueSeasonScheduleSettings>> Handle(
				GetLeagueSeasonScheduleSettingssByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return _context.LeagueSeasonScheduleSettings
					.Where(settings => request.LeagueSeasonScheduleSettingsIds.Contains(settings.Id));
			}
		}
	}
}
