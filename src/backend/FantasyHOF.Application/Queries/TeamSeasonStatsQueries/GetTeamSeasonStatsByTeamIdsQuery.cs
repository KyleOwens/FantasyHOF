using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamSeasonStatsQueries
{
    public sealed record GetTeamSeasonStatsByTeamIdsQuery(IEnumerable<int> TeamIds)
        : IRequest<IEnumerable<TeamSeasonStats>>
    {
        public sealed class GetTeamSeasonStatsByTeamIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetTeamSeasonStatsByTeamIdsQuery, IEnumerable<TeamSeasonStats>>
        {
            public async Task<IEnumerable<TeamSeasonStats>> Handle(GetTeamSeasonStatsByTeamIdsQuery request, CancellationToken cancellationToken)
            {
                return await database.TeamSeasonStats
                    .AsNoTracking()
                    .Where(stats => request.TeamIds.Contains(stats.TeamId))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
