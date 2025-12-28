
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.SportQueries
{
    public record GetSportByIdQuery(SportId SportId) : IRequest<Sport?>
    {
        public class GetSportByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetSportByIdQuery, Sport?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<Sport?> Handle(GetSportByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetSportsByIdsQuery([request.SportId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}