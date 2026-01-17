using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.StatQueries
{
    public sealed record GetStatsByIdsQuery(IEnumerable<StatId> StatIds)
        : IRequest<IEnumerable<Stat>>
    {
        public sealed class GetStatsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetStatsByIdsQuery, IEnumerable<Stat>>
        {
            public async Task<IEnumerable<Stat>> Handle(
                GetStatsByIdsQuery request,
                CancellationToken ct)
            {
                return await database.Stats
                    .AsNoTracking()
                    .Where(stat => request.StatIds.Contains(stat.Id))
                    .ToListAsync(ct);
            }
        }
    }
}
