using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScheduleSettingsQueries
{
    public record GetLeagueSeasonScheduleSettingsByIdQuery(int LeagueSeasonScheduleSettingsId) : IRequest<LeagueSeasonScheduleSettings?>
    {
        public class GetLeagueSeasonScheduleSettingsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonScheduleSettingsByIdQuery, LeagueSeasonScheduleSettings?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeasonScheduleSettings?> Handle(GetLeagueSeasonScheduleSettingsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonScheduleSettingssByIdsQuery([request.LeagueSeasonScheduleSettingsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
