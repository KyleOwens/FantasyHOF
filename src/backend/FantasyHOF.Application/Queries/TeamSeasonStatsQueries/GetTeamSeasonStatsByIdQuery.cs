
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamSeasonStatsQueries
{
    public record GetTeamSeasonStatsByIdQuery(int TeamSeasonStatsId) : IRequest<TeamSeasonStats?>
    {
        public class GetTeamSeasonStatsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetTeamSeasonStatsByIdQuery, TeamSeasonStats?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<TeamSeasonStats?> Handle(GetTeamSeasonStatsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetTeamSeasonStatsByIdsQuery([request.TeamSeasonStatsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}