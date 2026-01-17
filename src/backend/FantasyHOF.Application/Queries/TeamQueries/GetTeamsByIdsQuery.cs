using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamQueries
{
    public sealed record GetTeamsByIdsQuery(IEnumerable<int> TeamIds)
        : IRequest<IEnumerable<Team>>
    {
        public sealed class GetTeamsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetTeamsByIdsQuery, IEnumerable<Team>>
        {
            public async Task<IEnumerable<Team>> Handle(
                GetTeamsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.Teams
                    .AsNoTracking()
                    .Where(team => request.TeamIds.Contains(team.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
