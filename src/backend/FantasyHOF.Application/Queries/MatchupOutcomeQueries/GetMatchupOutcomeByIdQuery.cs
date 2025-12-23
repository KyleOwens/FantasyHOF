
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupOutcomeQueries
{
    public record GetMatchupOutcomeByIdQuery(MatchupOutcomeId MatchupOutcomeId) : IRequest<MatchupOutcome?>
    {
        public class GetMatchupOutcomeByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupOutcomeByIdQuery, MatchupOutcome?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<MatchupOutcome?> Handle(GetMatchupOutcomeByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetMatchupOutcomesByIdsQuery([request.MatchupOutcomeId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
