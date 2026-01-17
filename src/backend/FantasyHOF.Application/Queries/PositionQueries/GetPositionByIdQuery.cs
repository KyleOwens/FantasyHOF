
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.PositionQueries
{
    public record GetPositionByIdQuery(PositionId PositionId)
        : IRequest<Position?>
    {
        public class GetPositionByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetPositionByIdQuery, Position?>
        {
            public async Task<Position?> Handle(GetPositionByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetPositionsByIdsQuery([request.PositionId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}