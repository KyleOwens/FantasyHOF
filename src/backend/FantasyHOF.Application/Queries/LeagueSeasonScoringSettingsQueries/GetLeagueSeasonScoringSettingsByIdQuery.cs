using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries
{
    public record GetLeagueSeasonScoringSettingsByIdQuery(int LeagueSeasonScoringSettingsId)
        : IRequest<LeagueSeasonScoringSettings?>
    {
        public class GetLeagueSeasonScoringSettingsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonScoringSettingsByIdQuery, LeagueSeasonScoringSettings?>
        {
            public async Task<LeagueSeasonScoringSettings?> Handle(GetLeagueSeasonScoringSettingsByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetLeagueSeasonScoringSettingsByIdsQuery([request.LeagueSeasonScoringSettingsId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}