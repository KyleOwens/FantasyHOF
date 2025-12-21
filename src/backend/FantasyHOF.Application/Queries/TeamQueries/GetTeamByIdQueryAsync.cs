
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamQueries
{
    public record GetTeamByIdQuery(int TeamId) : IRequest<Team?>
    {
        public class GetTeamByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetTeamByIdQuery, Team?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<Team?> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetTeamsByIdsQuery([request.TeamId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}