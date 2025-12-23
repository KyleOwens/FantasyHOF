
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupOutcomeQueries
{
	public sealed record GetMatchupOutcomesByIdsQuery(IEnumerable<MatchupOutcomeId> MatchupOutcomeIds)
		: IRequest<IEnumerable<MatchupOutcome>>
	{
		public sealed class GetMatchupOutcomesByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetMatchupOutcomesByIdsQuery, IEnumerable<MatchupOutcome>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<MatchupOutcome>> Handle(
				GetMatchupOutcomesByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.MatchupOutcomes
					.Where(outcome => request.MatchupOutcomeIds.Contains(outcome.Id))
                    .ToListAsync();
			}
		}
	}
}
