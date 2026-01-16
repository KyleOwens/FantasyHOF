using FantasyHOF.Application.Queries.SportQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<Sport>]
    internal class SportTypeExtension
    {
        [ID]
        public int Id([Parent] Sport sport) => (int)sport.Id;
        public SportId Value([Parent] Sport sport) => sport.Id;

        public static async Task<Sport?> GetSportAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetSportByIdQuery((SportId)id), cancellationToken);
        }
    }
}
