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
        public sealed class GetLeagueImportStatusesByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueImportStatusesByIdsQuery, IEnumerable<LeagueImportStatus>>
        {
            public async Task<IEnumerable<LeagueImportStatus>> Handle(
                GetLeagueImportStatusesByIdsQuery request,
                CancellationToken ct)
            {
                return await database.LeagueImportStatuses
                    .AsNoTracking()
                    .Where(status => request.LeagueImportStatusIds.Contains(status.Id))
                    .ToListAsync(ct);
            }
        }
    }
}