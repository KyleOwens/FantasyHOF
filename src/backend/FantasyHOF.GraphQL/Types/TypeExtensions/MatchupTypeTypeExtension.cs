using FantasyHOF.Application.Queries.MatchupTypeQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<MatchupType>]
    internal class MatchupTypeTypeExtension
    {
        [ID]
        public int Id([Parent] MatchupType type) => (int)type.Id;
        public MatchupTypeId Value([Parent] MatchupType type) => type.Id;

        public static async Task<MatchupType?> GetMatchupTypeAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetMatchupTypeByIdQuery((MatchupTypeId)id), cancellationToken);
        }
    }
}
