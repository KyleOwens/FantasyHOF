using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.AccumulatedStatQueries
{
    public sealed record GetAccumulatedStatsByMatchupRosterSpotIdsQuery(IEnumerable<int> MatchupRosterSpotIds)
        : IRequest<IEnumerable<AccumulatedStat>>;

    public sealed class GetAccumulatedStatsByMatchupRosterSpotIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetAccumulatedStatsByMatchupRosterSpotIdsQuery, IEnumerable<AccumulatedStat>>
    {
        public async Task<IEnumerable<AccumulatedStat>> Handle(GetAccumulatedStatsByMatchupRosterSpotIdsQuery request, CancellationToken cancellationToken)
        {
            return await database.AccumulatedStats
                .AsNoTracking()
                .Where(item => request.MatchupRosterSpotIds.Contains(item.MatchupRosterSpotId))
                .ToListAsync(cancellationToken);
        }
    }
}
