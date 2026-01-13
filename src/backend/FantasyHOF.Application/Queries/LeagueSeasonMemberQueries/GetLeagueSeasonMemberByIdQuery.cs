using FantasyHOF.Domain.ComplexIds;
using MediatR;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
    public record GetLeagueSeasonMemberByIdQuery(LeagueSeasonMemberId LeagueSeasonMemberId) : IRequest<LeagueSeasonMember?>
    {
        public class GetLeagueSeasonMemberByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueSeasonMemberByIdQuery, LeagueSeasonMember?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeasonMember?> Handle(GetLeagueSeasonMemberByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonMembersByIdsQuery([request.LeagueSeasonMemberId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}