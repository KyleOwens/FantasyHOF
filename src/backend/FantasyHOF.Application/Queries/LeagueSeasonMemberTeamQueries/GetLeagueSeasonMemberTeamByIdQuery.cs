
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries
{
    public record GetLeagueSeasonMemberTeamByIdQuery(LeagueSeasonMemberTeamId LeagueSeasonMemberTeamId) : IRequest<LeagueSeasonMemberTeam?>
    {
        public class GetLeagueSeasonMemberTeamByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonMemberTeamByIdQuery, LeagueSeasonMemberTeam?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeasonMemberTeam?> Handle(GetLeagueSeasonMemberTeamByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonMemberTeamsByIdsQuery([request.LeagueSeasonMemberTeamId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}