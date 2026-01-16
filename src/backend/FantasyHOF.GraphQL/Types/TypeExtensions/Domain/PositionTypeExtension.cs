using FantasyHOF.Application.Queries.PositionQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<Position>]
    internal class PositionTypeExtension
    {
        public int Id([Parent] Position position) => (int)position.Id;
        public PositionId Value([Parent] Position position) => position.Id;

        public static async Task<Position?> GetPositionAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetPositionByIdQuery((PositionId)id), cancellationToken);
        }
    }
}
