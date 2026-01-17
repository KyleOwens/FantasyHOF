using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
    public record GetLeagueSeasonMemberByIdQuery(LeagueSeasonMemberId LeagueSeasonMemberId)
        : IRequest<LeagueSeasonMember?>
    {
        public class GetLeagueSeasonMemberByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonMemberByIdQuery, LeagueSeasonMember?>
        {
            public async Task<LeagueSeasonMember?> Handle(GetLeagueSeasonMemberByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetLeagueSeasonMembersByIdsQuery([request.LeagueSeasonMemberId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}