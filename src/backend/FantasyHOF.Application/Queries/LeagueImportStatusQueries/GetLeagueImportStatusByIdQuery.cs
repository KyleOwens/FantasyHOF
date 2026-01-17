
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueImportStatusQueries
{
    public record GetLeagueImportStatusByIdQuery(LeagueImportStatusId LeagueImportStatusId)
        : IRequest<LeagueImportStatus?>
    {
        public class GetLeagueImportStatusByIdQueryHandler(IMediator mediator)
            : IRequestHandler<GetLeagueImportStatusByIdQuery, LeagueImportStatus?>
        {
            public async Task<LeagueImportStatus?> Handle(GetLeagueImportStatusByIdQuery request, CancellationToken ct)
            {
                return (await mediator.Send(new GetLeagueImportStatusesByIdsQuery([request.LeagueImportStatusId]), ct))
                    .FirstOrDefault();
            }
        }
    }
}