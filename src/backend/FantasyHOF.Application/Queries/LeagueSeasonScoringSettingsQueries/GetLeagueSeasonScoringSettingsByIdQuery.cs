using FantasyHOF.EntityFramework;
using MediatR;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringSettingsQueries
{
    public record GetLeagueSeasonScoringSettingsByIdQuery(int LeagueSeasonScoringSettingsId) : IRequest<LeagueSeasonScoringSettings?>
    {
        public class GetLeagueSeasonScoringSettingsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonScoringSettingsByIdQuery, LeagueSeasonScoringSettings?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeasonScoringSettings?> Handle(GetLeagueSeasonScoringSettingsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonScoringSettingsByIdsQuery([request.LeagueSeasonScoringSettingsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}