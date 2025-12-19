
using FantasyHOF.Application.Queries.LeagueSeasonSettingsQueries;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonSettingss
{
    public record GetLeagueSeasonSettingsByIdQuery(int LeagueSeasonSettingsId) : IRequest<LeagueSeasonSettings?>
    {
        public class GetLeagueSeasonSettingsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonSettingsByIdQuery, LeagueSeasonSettings?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeasonSettings?> Handle(GetLeagueSeasonSettingsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonSettingsByIdsQuery([request.LeagueSeasonSettingsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
