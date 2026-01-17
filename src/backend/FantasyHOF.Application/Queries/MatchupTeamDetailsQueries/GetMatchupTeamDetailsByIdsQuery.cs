using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupTeamDetailsQueries
{
    public sealed record GetMatchupTeamDetailsByIdsQuery(IEnumerable<int> MatchupTeamDetailsIds)
        : IRequest<IEnumerable<MatchupTeamDetails>>
    {
        public sealed class GetMatchupTeamDetailsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetMatchupTeamDetailsByIdsQuery, IEnumerable<MatchupTeamDetails>>
        {
            public async Task<IEnumerable<MatchupTeamDetails>> Handle(
                GetMatchupTeamDetailsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.MatchupTeamDetails
                    .AsNoTracking()
                    .Where(item => request.MatchupTeamDetailsIds.Contains(item.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}