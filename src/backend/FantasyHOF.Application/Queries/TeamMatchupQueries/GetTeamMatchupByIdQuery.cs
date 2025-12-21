
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamMatchupQueries
{
    public record GetTeamMatchupByIdQuery(int TeamMatchupId) : IRequest<TeamMatchup?>
    {
        public class GetTeamMatchupByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetTeamMatchupByIdQuery, TeamMatchup?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<TeamMatchup?> Handle(GetTeamMatchupByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetTeamMatchupsByIdsQuery([request.TeamMatchupId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}