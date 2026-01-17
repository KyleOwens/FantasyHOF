
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.PlayerQueries
{
    public record GetPlayerByIdQuery(int PlayerId)
        : IRequest<Player?>
    {
        public class GetPlayerByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetPlayerByIdQuery, Player?>
        {
            public async Task<Player?> Handle(GetPlayerByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetPlayersByIdsQuery([request.PlayerId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}