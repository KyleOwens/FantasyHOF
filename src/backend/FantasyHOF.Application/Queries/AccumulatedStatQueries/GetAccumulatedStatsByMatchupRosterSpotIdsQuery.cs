
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.AccumulatedStatQueries
{
    public sealed record GetAccumulatedStatsByMatchupRosterSpotIdsQuery(IEnumerable<int> MatchupRosterSpotIds) : IRequest<IEnumerable<AccumulatedStat>>;

    public sealed class GetAccumulatedStatsByMatchupRosterSpotIdsQueryHandler : IRequestHandler<GetAccumulatedStatsByMatchupRosterSpotIdsQuery, IEnumerable<AccumulatedStat>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetAccumulatedStatsByMatchupRosterSpotIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<AccumulatedStat>> Handle(GetAccumulatedStatsByMatchupRosterSpotIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.AccumulatedStats
                .Where(item => request.MatchupRosterSpotIds.Contains(item.MatchupRosterSpotId))
                .ToListAsync();
        }
    }
}
