
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.TeamMatchupQueries
{
    public sealed record GetTeamMatchupsByTeamIdsQuery(IEnumerable<int> TeamIds) : IRequest<IEnumerable<TeamMatchup>>;

    public sealed class GetTeamMatchupsByTeamIdsQueryHandler : IRequestHandler<GetTeamMatchupsByTeamIdsQuery, IEnumerable<TeamMatchup>>
    {
        private readonly FantasyHOFDBContext _context;

        public GetTeamMatchupsByTeamIdsQueryHandler(FantasyHOFDBContext context) => _context = context;

        public async Task<IEnumerable<TeamMatchup>> Handle(GetTeamMatchupsByTeamIdsQuery request, CancellationToken cancellationToken)
        {
            return _context.TeamMatchups
                .Where(matchup => request.TeamIds.Contains(matchup.TeamId));
        }
    }
}

