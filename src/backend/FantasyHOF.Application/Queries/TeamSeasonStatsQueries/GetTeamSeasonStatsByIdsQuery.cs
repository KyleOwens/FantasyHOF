using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamSeasonStatsQueries
{
    public sealed record GetTeamSeasonStatsByIdsQuery(IEnumerable<int> TeamSeasonStatsIds)
        : IRequest<IEnumerable<TeamSeasonStats>>
    {
        public sealed class GetTeamSeasonStatsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetTeamSeasonStatsByIdsQuery, IEnumerable<TeamSeasonStats>>
        {
            public async Task<IEnumerable<TeamSeasonStats>> Handle(
                GetTeamSeasonStatsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.TeamSeasonStats
                    .AsNoTracking()
                    .Where(stats => request.TeamSeasonStatsIds.Contains(stats.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}