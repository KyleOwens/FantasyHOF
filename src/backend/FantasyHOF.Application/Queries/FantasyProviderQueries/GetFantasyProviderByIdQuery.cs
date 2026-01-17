
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.FantasyProviderQueries
{
    public record GetFantasyProviderByIdQuery(FantasyProviderId FantasyProviderId)
        : IRequest<FantasyProvider?>
    {
        public class GetFantasyProviderByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetFantasyProviderByIdQuery, FantasyProvider?>
        {
            public async Task<FantasyProvider?> Handle(GetFantasyProviderByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetFantasyProvidersByIdsQuery([request.FantasyProviderId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
