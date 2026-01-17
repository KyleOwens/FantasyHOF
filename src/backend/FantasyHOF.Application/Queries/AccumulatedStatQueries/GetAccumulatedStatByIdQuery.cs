using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.AccumulatedStatQueries
{
    public record GetAccumulatedStatByIdQuery(int AccumulatedStatId)
        : IRequest<AccumulatedStat?>
    {
        public class GetAccumulatedStatByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetAccumulatedStatByIdQuery, AccumulatedStat?>
        {
            public async Task<AccumulatedStat?> Handle(GetAccumulatedStatByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetAccumulatedStatsByIdsQuery([request.AccumulatedStatId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}