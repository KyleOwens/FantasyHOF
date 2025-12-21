
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.Application.Queries.FantasyMemberQueries
{
    public record GetFantasyMemberByIdQuery(int FantasyMemberId) : IRequest<FantasyMember?>
    {
        public class GetFantasyMemberByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetFantasyMemberByIdQuery, FantasyMember?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<FantasyMember?> Handle(GetFantasyMemberByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetFantasyMembersByIdsQuery([request.FantasyMemberId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
