using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupTeamDetailsQueries
{
    public sealed record GetMatchupTeamDetailsByIdsQuery(IEnumerable<int> MatchupTeamDetailsIds)
        : IRequest<IEnumerable<MatchupTeamDetails>>
    {
        public sealed class GetMatchupTeamDetailsByIdsQueryHandler(FantasyHOFDBContext context)
                        : IRequestHandler<GetMatchupTeamDetailsByIdsQuery, IEnumerable<MatchupTeamDetails>>
        {
            private readonly FantasyHOFDBContext _context = context;

            public async Task<IEnumerable<MatchupTeamDetails>> Handle(
                GetMatchupTeamDetailsByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return _context.MatchupTeamDetails
                    .AsNoTracking()
                    .Where(item => request.MatchupTeamDetailsIds.Contains(item.Id));
            }
        }
    }
}