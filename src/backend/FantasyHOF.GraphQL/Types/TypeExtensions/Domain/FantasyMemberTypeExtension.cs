using FantasyHOF.Application.Queries.FantasyMemberQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using HotChocolate.Authorization;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [Authorize]
    [ExtendObjectType<FantasyMember>]
    internal class FantasyMemberTypeExtension
    {
        [ID<FantasyProvider>]
        public int FantasyProviderId([Parent] FantasyMember member) => (int)member.FantasyProviderId;

        public async Task<FantasyProvider> GetFantasyProviderAsync(
            [Parent] FantasyMember member,
            IFantasyProvidersByIdsDataLoader providers,
            CancellationToken cancellationToken)
        {
            return await providers.LoadRequiredAsync(member.FantasyProviderId, cancellationToken);
        }

        public static async Task<FantasyMember?> GetFantasyMemberAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetFantasyMemberByIdQuery(id), cancellationToken);
        }
    }
}
