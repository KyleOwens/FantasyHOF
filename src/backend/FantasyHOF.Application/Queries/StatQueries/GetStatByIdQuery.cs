
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.StatQueries
{
    public record GetStatByIdQuery(StatId StatId) : IRequest<Stat?>
    {
        public class GetStatByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetStatByIdQuery, Stat?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<Stat?> Handle(GetStatByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetStatsByIdsQuery([request.StatId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}