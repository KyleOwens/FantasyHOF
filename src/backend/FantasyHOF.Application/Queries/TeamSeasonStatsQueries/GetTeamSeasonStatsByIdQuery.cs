
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.TeamSeasonStatsQueries
{
    public record GetTeamSeasonStatsByIdQuery(int TeamSeasonStatsId)
        : IRequest<TeamSeasonStats?>
    {
        public class GetTeamSeasonStatsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetTeamSeasonStatsByIdQuery, TeamSeasonStats?>
        {
            public async Task<TeamSeasonStats?> Handle(GetTeamSeasonStatsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetTeamSeasonStatsByIdsQuery([request.TeamSeasonStatsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}