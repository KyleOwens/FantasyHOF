using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueMemberQueries
{
    public sealed record GetLeagueMembersByLeagueIdsQuery(IEnumerable<int> LeagueIds) : IRequest<IEnumerable<LeagueMember>>;

    public sealed class GetLeagueMembersByLeagueIdsQueryHandler : IRequestHandler<GetLeagueMembersByLeagueIdsQuery, IEnumerable<LeagueMember>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueMembersByLeagueIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueMember>> Handle(GetLeagueMembersByLeagueIdsQuery request, CancellationToken cancellationToken)
        {
            return await _context.LeagueMembers
                .AsNoTracking()
                .Where(leagueMember => request.LeagueIds.Contains(leagueMember.LeagueId))
                .ToListAsync();
        }
    }
}
