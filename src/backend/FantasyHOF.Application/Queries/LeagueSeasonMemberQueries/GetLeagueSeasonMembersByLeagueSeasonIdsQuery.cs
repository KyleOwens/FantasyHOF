
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueSeasonMemberQueries
{
    public sealed record GetLeagueSeasonMembersByLeagueSeasonIdsQuery(IEnumerable<int> LeagueSeasonIds) : IRequest<IEnumerable<LeagueSeasonMember>>;

    public sealed class GetLeagueSeasonMembersByLeagueSeasonIdsQueryHandler : IRequestHandler<GetLeagueSeasonMembersByLeagueSeasonIdsQuery, IEnumerable<LeagueSeasonMember>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetLeagueSeasonMembersByLeagueSeasonIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<LeagueSeasonMember>> Handle(GetLeagueSeasonMembersByLeagueSeasonIdsQuery request, CancellationToken cancellationToken)
        {
            return _context.LeagueSeasonMembers
                .Where(seasonMember => request.LeagueSeasonIds.Contains(seasonMember.LeagueSeasonId));
        }
    }
}


