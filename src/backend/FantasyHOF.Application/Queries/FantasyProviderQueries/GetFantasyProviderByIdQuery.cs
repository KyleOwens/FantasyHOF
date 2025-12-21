
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.FantasyProviderQueries
{
    public record GetFantasyProviderByIdQuery(FantasyProviderId FantasyProviderId) : IRequest<FantasyProvider?>
    {
        public class GetFantasyProviderByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetFantasyProviderByIdQuery, FantasyProvider?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<FantasyProvider?> Handle(GetFantasyProviderByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetFantasyProvidersByIdsQuery([request.FantasyProviderId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
