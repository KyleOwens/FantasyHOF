
using FantasyHOF.Application.Queries.UserQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
    internal static class UsersByIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<Guid, User>> GetUsersByIdsAsync(
            IReadOnlyList<Guid> ids,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var users = await mediator.Send(
                new GetUsersByIdsQuery(ids),
                cancellationToken);

            return users.ToDictionary(user => user.Id);
        }
    }
}