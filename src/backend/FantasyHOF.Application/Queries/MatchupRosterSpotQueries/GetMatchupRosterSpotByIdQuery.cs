
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupRosterSpotQueries
{
    public record GetMatchupRosterSpotByIdQuery(int MatchupRosterSpotId)
        : IRequest<MatchupRosterSpot?>
    {
        public class GetMatchupRosterSpotByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupRosterSpotByIdQuery, MatchupRosterSpot?>
        {
            public async Task<MatchupRosterSpot?> Handle(GetMatchupRosterSpotByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetMatchupRosterSpotsByIdsQuery([request.MatchupRosterSpotId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}