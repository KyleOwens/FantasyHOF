
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.PlayerQueries
{
    public record GetPlayerByIdQuery(int PlayerId) : IRequest<Player?>
    {
        public class GetPlayerByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetPlayerByIdQuery, Player?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetPlayersByIdsQuery([request.PlayerId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}