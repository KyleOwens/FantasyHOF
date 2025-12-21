using FantasyHOF.Application.Queries.FantasyProviderQueries;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<FantasyProvider>]
    internal class FantasyProviderTypeExtension
    {
        [ID]
        public int Id([Parent] FantasyProvider provider) => (int)provider.Id;
        public FantasyProviderId Value([Parent] FantasyProvider provider) => provider.Id;

        public static async Task<FantasyProvider?> GetFantasyProviderAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetFantasyProviderByIdQuery((FantasyProviderId)id), cancellationToken);
        }
    }
}
