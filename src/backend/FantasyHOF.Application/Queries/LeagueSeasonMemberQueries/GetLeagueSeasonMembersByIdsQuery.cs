
using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
    public sealed record GetLeagueSeasonMembersByIdsQuery(IEnumerable<LeagueSeasonMemberId> LeagueSeasonMemberIds)
        : IRequest<IEnumerable<LeagueSeasonMember>>
    {
        public sealed class GetLeagueSeasonMembersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueSeasonMembersByIdsQuery, IEnumerable<LeagueSeasonMember>>
        {
            public async Task<IEnumerable<LeagueSeasonMember>> Handle(
                GetLeagueSeasonMembersByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.LeagueSeasonMembers
                    .AsNoTracking()
                    .Where(seasonMember => request.LeagueSeasonMemberIds
                        .Any(id => id.LeagueSeasonId == seasonMember.LeagueSeasonId && id.MemberId == seasonMember.MemberId))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
