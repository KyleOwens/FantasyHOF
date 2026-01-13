using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueImportStatusQueries
{
    public sealed record GetLeagueImportStatusesByIdsQuery(IEnumerable<LeagueImportStatusId> LeagueImportStatusIds)
        : IRequest<IEnumerable<LeagueImportStatus>>
    {
        public sealed class GetLeagueImportStatusesByIdsQueryHandler(FantasyHOFDBContext context)
                        : IRequestHandler<GetLeagueImportStatusesByIdsQuery, IEnumerable<LeagueImportStatus>>
        {
            private readonly FantasyHOFDBContext _context = context;

            public async Task<IEnumerable<LeagueImportStatus>> Handle(
                GetLeagueImportStatusesByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return _context.LeagueImportStatuses
                    .Where(status => request.LeagueImportStatusIds.Contains(status.Id));
            }
        }
    }
}