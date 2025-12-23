
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupTypeQueries
{
    public record GetMatchupTypeByIdQuery(MatchupTypeId MatchupTypeId) : IRequest<MatchupType?>
    {
        public class GetMatchupTypeByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupTypeByIdQuery, MatchupType?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<MatchupType?> Handle(GetMatchupTypeByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetMatchupTypesByIdsQuery([request.MatchupTypeId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}