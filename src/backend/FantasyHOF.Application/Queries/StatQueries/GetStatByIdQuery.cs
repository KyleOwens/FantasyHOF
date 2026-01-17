
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.StatQueries
{
    public record GetStatByIdQuery(StatId StatId) : IRequest<Stat?>
    {
        public class GetStatByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetStatByIdQuery, Stat?>
        {
            public async Task<Stat?> Handle(GetStatByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetStatsByIdsQuery([request.StatId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}