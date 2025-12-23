
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.PlayerQueries
{
	public sealed record GetPlayersByIdsQuery(IEnumerable<int> PlayerIds)
		: IRequest<IEnumerable<Player>>
	{
		public sealed class GetPlayersByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetPlayersByIdsQuery, IEnumerable<Player>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<Player>> Handle(
				GetPlayersByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.Players
					.Where(player => request.PlayerIds.Contains(player.Id))
                    .ToListAsync();
			}
		}
	}
}