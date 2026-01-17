
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamMatchupQueries
{
    public record GetTeamMatchupByIdQuery(int TeamMatchupId)
        : IRequest<TeamMatchup?>
    {
        public class GetTeamMatchupByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetTeamMatchupByIdQuery, TeamMatchup?>
        {
            public async Task<TeamMatchup?> Handle(GetTeamMatchupByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetTeamMatchupsByIdsQuery([request.TeamMatchupId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}