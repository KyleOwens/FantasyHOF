
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamSeasonStatsQueries
{
    public sealed record GetTeamSeasonStatsByTeamIdsQuery(IEnumerable<int> TeamIds) : IRequest<IEnumerable<TeamSeasonStats>>;

    public sealed class GetTeamSeasonStatsByTeamIdsQueryHandler : IRequestHandler<GetTeamSeasonStatsByTeamIdsQuery, IEnumerable<TeamSeasonStats>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetTeamSeasonStatsByTeamIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<TeamSeasonStats>> Handle(GetTeamSeasonStatsByTeamIdsQuery request, CancellationToken cancellationToken)
        {
            return _context.TeamSeasonStats
                .Where(stats => request.TeamIds.Contains(stats.TeamId));
        }
    }
}
