
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.MatchupTeamDetailsQueries
{
    public record GetMatchupTeamDetailsByIdQuery(int MatchupTeamDetailsId) : IRequest<MatchupTeamDetails?>
    {
        public class GetMatchupTeamDetailsByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetMatchupTeamDetailsByIdQuery, MatchupTeamDetails?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<MatchupTeamDetails?> Handle(GetMatchupTeamDetailsByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetMatchupTeamDetailsByIdsQuery([request.MatchupTeamDetailsId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}