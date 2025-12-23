
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
    public record GetMatchupRosterSpotByIdQuery(int MatchupRosterSpotId) : IRequest<MatchupRosterSpot?>
    {
        public class GetMatchupRosterSpotByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupRosterSpotByIdQuery, MatchupRosterSpot?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<MatchupRosterSpot?> Handle(GetMatchupRosterSpotByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetMatchupRosterSpotsByIdsQuery([request.MatchupRosterSpotId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}