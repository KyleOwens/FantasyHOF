
using FantasyHOF.Application.Queries.MatchupOutcomeQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class MatchupOutcomesByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<MatchupOutcomeId, MatchupOutcome>> GetMatchupOutcomesByIdsAsync(
			IReadOnlyList<MatchupOutcomeId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var outcomes = await mediator.Send(
				new GetMatchupOutcomesByIdsQuery(ids),
				cancellationToken);

			return outcomes.ToDictionary(outcome => outcome.Id);
		}
	}
}