
using FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries
{
    public record GetLeagueSeasonScoringItemByIdQuery(int LeagueSeasonScoringItemId) : IRequest<LeagueSeasonScoringItem?>
    {
        public class GetLeagueSeasonScoringItemByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonScoringItemByIdQuery, LeagueSeasonScoringItem?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeasonScoringItem?> Handle(GetLeagueSeasonScoringItemByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonScoringItemsByIdsQuery([request.LeagueSeasonScoringItemId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
