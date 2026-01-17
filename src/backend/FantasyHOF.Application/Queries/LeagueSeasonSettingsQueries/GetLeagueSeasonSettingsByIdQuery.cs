using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries
{
    public record GetLeagueSeasonSettingsByIdQuery(int LeagueSeasonSettingsId)
        : IRequest<LeagueSeasonSettings?>
    {
        public class GetLeagueSeasonSettingsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonSettingsByIdQuery, LeagueSeasonSettings?>
        {
            public async Task<LeagueSeasonSettings?> Handle(GetLeagueSeasonSettingsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetLeagueSeasonSettingsByIdsQuery([request.LeagueSeasonSettingsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
