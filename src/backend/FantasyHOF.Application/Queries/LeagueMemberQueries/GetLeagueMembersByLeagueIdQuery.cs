using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueMemberQueries
{
    public sealed record GetLeagueMembersByLeagueIdsQuery(IEnumerable<int> LeagueIds)
        : IRequest<IEnumerable<LeagueMember>>;

    public sealed class GetLeagueMembersByLeagueIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueMembersByLeagueIdsQuery, IEnumerable<LeagueMember>>
    {
        public async Task<IEnumerable<LeagueMember>> Handle(GetLeagueMembersByLeagueIdsQuery request, CancellationToken ct)
        {
            return await database.LeagueMembers
                .AsNoTracking()
                .Where(leagueMember => request.LeagueIds.Contains(leagueMember.LeagueId))
                .ToListAsync(ct);
        }
    }
}
