
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.PositionQueries
{
    public record GetPositionByIdQuery(PositionId PositionId) : IRequest<Position?>
    {
        public class GetPositionByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetPositionByIdQuery, Position?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<Position?> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetPositionsByIdsQuery([request.PositionId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}