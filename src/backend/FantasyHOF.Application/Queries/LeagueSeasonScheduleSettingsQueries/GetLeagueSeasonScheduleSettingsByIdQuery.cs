using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries
{
    public record GetLeagueSeasonScheduleSettingsByIdQuery(int LeagueSeasonScheduleSettingsId)
        : IRequest<LeagueSeasonScheduleSettings?>
    {
        public class GetLeagueSeasonScheduleSettingsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonScheduleSettingsByIdQuery, LeagueSeasonScheduleSettings?>
        {
            public async Task<LeagueSeasonScheduleSettings?> Handle(GetLeagueSeasonScheduleSettingsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetLeagueSeasonScheduleSettingssByIdsQuery([request.LeagueSeasonScheduleSettingsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
