
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.AccumulatedStatQueries
{
    public record GetAccumulatedStatByIdQuery(int AccumulatedStatId) : IRequest<AccumulatedStat?>
    {
        public class GetAccumulatedStatByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetAccumulatedStatByIdQuery, AccumulatedStat?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<AccumulatedStat?> Handle(GetAccumulatedStatByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetAccumulatedStatsByIdsQuery([request.AccumulatedStatId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}