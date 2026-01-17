using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonScoringItemQueries
{
    public record GetLeagueSeasonScoringItemByIdQuery(int LeagueSeasonScoringItemId)
        : IRequest<LeagueSeasonScoringItem?>
    {
        public class GetLeagueSeasonScoringItemByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonScoringItemByIdQuery, LeagueSeasonScoringItem?>
        {
            public async Task<LeagueSeasonScoringItem?> Handle(GetLeagueSeasonScoringItemByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetLeagueSeasonScoringItemsByIdsQuery([request.LeagueSeasonScoringItemId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}
