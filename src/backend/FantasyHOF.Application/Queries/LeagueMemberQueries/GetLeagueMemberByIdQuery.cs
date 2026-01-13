
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
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueMember?> Handle(GetLeagueMemberByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueMembersByIdsQuery([request.LeagueMemberId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}