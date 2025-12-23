using FantasyHOF.Application.Queries.PlayerQueries;
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
	[ExtendObjectType<Player>]
	internal class PlayerTypeExtension
	{
		[ID<FantasyProvider>]
		public int ProviderId([Parent] Player player) => (int) player.ProviderId;

		public async Task<FantasyProvider> GetProviderAsync(
			[Parent] Player player,
			IFantasyProvidersByIdsDataLoader providers,
			CancellationToken cancellationToken)
		{
			return await providers.LoadRequiredAsync(player.ProviderId, cancellationToken);
		}
		
		public static async Task<Player?> GetPlayerAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetPlayerByIdQuery(id), cancellationToken);
		}
    }
}
