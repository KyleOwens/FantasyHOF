using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonQueries
{
    public record GetLeagueSeasonByIdQuery(int LeagueSeasonId) : IRequest<LeagueSeason?>
    {
        public class GetLeagueSeasonByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonByIdQuery, LeagueSeason?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeason?> Handle(GetLeagueSeasonByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonsByIdsQuery([request.LeagueSeasonId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
