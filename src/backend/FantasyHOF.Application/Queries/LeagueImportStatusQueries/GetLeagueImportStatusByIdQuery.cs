
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueImportStatusQueries
{
    public record GetLeagueImportStatusByIdQuery(LeagueImportStatusId LeagueImportStatusId) : IRequest<LeagueImportStatus?>
    {
        public class GetLeagueImportStatusByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueImportStatusByIdQuery, LeagueImportStatus?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueImportStatus?> Handle(GetLeagueImportStatusByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueImportStatusesByIdsQuery([request.LeagueImportStatusId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}