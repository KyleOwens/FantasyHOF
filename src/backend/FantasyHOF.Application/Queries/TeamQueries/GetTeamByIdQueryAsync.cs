
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamQueries
{
    public record GetTeamByIdQuery(int TeamId)
        : IRequest<Team?>
    {
        public class GetTeamByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetTeamByIdQuery, Team?>
        {
            public async Task<Team?> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetTeamsByIdsQuery([request.TeamId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}