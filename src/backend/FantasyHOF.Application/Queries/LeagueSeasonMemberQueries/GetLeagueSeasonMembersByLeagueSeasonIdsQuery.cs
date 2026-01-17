using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
    public sealed record GetLeagueSeasonMembersByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds)
        : IRequest<IEnumerable<LeagueSeasonMember>>;

    public sealed class GetLeagueSeasonMembersByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueSeasonMembersByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonMember>>
    {
        public async Task<IEnumerable<LeagueSeasonMember>> Handle(GetLeagueSeasonMembersByLeagueSeasonIdsQuery request, CancellationToken ct)
        {
            return await database.LeagueSeasonMembers
                .AsNoTracking()
                .Where(seasonMember => request.LeagueSeasonIds.Contains(seasonMember.LeagueSeasonId))
                .ToListAsync(ct);
        }
    }
}


