
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberTeamQueries
{
    public record GetLeagueSeasonMemberTeamByIdQuery(LeagueSeasonMemberTeamId LeagueSeasonMemberTeamId)
        : IRequest<LeagueSeasonMemberTeam?>
    {
        public class GetLeagueSeasonMemberTeamByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonMemberTeamByIdQuery, LeagueSeasonMemberTeam?>
        {
            public async Task<LeagueSeasonMemberTeam?> Handle(GetLeagueSeasonMemberTeamByIdQuery request, CancellationToken cancellationToken)
            {
                return (await mediator.Send(new GetLeagueSeasonMemberTeamsByIdsQuery([request.LeagueSeasonMemberTeamId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}