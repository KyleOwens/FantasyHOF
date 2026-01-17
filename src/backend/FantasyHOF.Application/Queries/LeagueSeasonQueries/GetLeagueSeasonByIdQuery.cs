using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonQueries
{
    public record GetLeagueSeasonByIdQuery(int LeagueSeasonId)
        : IRequest<LeagueSeason?>
    {
        public class GetLeagueSeasonByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonByIdQuery, LeagueSeason?>
        {
            public async Task<LeagueSeason?> Handle(GetLeagueSeasonByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetLeagueSeasonsByIdsQuery([request.LeagueSeasonId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
