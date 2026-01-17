
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.SportQueries
{
    public record GetSportByIdQuery(SportId SportId)
        : IRequest<Sport?>
    {
        public class GetSportByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetSportByIdQuery, Sport?>
        {
            public async Task<Sport?> Handle(GetSportByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetSportsByIdsQuery([request.SportId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}