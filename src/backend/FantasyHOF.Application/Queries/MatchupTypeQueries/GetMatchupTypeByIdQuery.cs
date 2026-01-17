
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupTypeQueries
{
    public record GetMatchupTypeByIdQuery(MatchupTypeId MatchupTypeId)
        : IRequest<MatchupType?>
    {
        public class GetMatchupTypeByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupTypeByIdQuery, MatchupType?>
        {
            public async Task<MatchupType?> Handle(GetMatchupTypeByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetMatchupTypesByIdsQuery([request.MatchupTypeId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}