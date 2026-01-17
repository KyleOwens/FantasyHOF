using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.AccumulatedStatQueries
{
    public sealed record GetAccumulatedStatsByIdsQuery(IEnumerable<int> AccumulatedStatIds)
        : IRequest<IEnumerable<AccumulatedStat>>
    {
        public sealed class GetAccumulatedStatsByIdsQueryHandler(FantasyHOFDBContext database)
                        : IRequestHandler<GetAccumulatedStatsByIdsQuery, IEnumerable<AccumulatedStat>>
        {
            public async Task<IEnumerable<AccumulatedStat>> Handle(
                GetAccumulatedStatsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.AccumulatedStats
                    .AsNoTracking()
                    .Where(stat => request.AccumulatedStatIds.Contains(stat.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}