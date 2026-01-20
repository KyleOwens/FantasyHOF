using FantasyHOF.Application.Queries.UserQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaderDefinitions
{
    internal static class UsersByIdsDataLoaderDefinition
    {
        [DataLoader]
        public static async Task<Dictionary<string, User>> GetUsersByIdsAsync(
            IReadOnlyList<string> ids,
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