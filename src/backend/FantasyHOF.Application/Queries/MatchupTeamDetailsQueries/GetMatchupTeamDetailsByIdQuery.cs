
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupTeamDetailsQueries
{
    public record GetMatchupTeamDetailsByIdQuery(int MatchupTeamDetailsId)
        : IRequest<MatchupTeamDetails?>
    {
        public class GetMatchupTeamDetailsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupTeamDetailsByIdQuery, MatchupTeamDetails?>
        {
            public async Task<MatchupTeamDetails?> Handle(GetMatchupTeamDetailsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetMatchupTeamDetailsByIdsQuery([request.MatchupTeamDetailsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}