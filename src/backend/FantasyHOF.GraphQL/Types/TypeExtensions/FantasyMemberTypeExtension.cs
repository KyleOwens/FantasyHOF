using FantasyHOF.Application.Queries.FantasyMemberQueries;
using FantasyHOF.Domain.Types;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
	[Node]
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
