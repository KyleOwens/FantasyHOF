using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupOutcomeQueries
{
    public sealed record GetMatchupOutcomesByIdsQuery(IEnumerable<MatchupOutcomeId> MatchupOutcomeIds)
        : IRequest<IEnumerable<MatchupOutcome>>
    {
        public sealed class GetMatchupOutcomesByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetMatchupOutcomesByIdsQuery, IEnumerable<MatchupOutcome>>
        {
            public async Task<IEnumerable<MatchupOutcome>> Handle(
                GetMatchupOutcomesByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.MatchupOutcomes
                    .AsNoTracking()
                    .Where(outcome => request.MatchupOutcomeIds.Contains(outcome.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
