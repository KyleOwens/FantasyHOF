using FantasyHOF.Application.Queries.MatchupOutcomeQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<MatchupOutcome>]
    internal class MatchupOutcomeTypeExtension
    {
        [ID]
        public int Id([Parent] MatchupOutcome outcome) => (int)outcome.Id;
        public MatchupOutcomeId Value([Parent] MatchupOutcome outcome) => outcome.Id;

        public static async Task<MatchupOutcome?> GetMatchupOutcomeAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetMatchupOutcomeByIdQuery((MatchupOutcomeId)id), cancellationToken);
        }
    }
}
