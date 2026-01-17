
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueMemberQueries
{
    public record GetLeagueMemberByIdQuery(LeagueMemberId LeagueMemberId) : IRequest<LeagueMember?>
    {
        public class GetLeagueMemberByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueMemberByIdQuery, LeagueMember?>
        {
            public async Task<LeagueMember?> Handle(GetLeagueMemberByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetLeagueMembersByIdsQuery([request.LeagueMemberId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}