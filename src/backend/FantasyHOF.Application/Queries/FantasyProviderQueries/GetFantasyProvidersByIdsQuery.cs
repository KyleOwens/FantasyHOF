using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.FantasyProviderQueries
{
	public sealed record GetFantasyProvidersByIdsQuery(IEnumerable<FantasyProviderId> FantasyProviderIds)
		: IRequest<IEnumerable<FantasyProvider>>
	{
		public sealed class GetFantasyProvidersByIdsQueryHandler(FantasyHOFDBContext context)
						: IRequestHandler<GetFantasyProvidersByIdsQuery, IEnumerable<FantasyProvider>>
		{
			private readonly FantasyHOFDBContext _context = context;

			public async Task<IEnumerable<FantasyProvider>> Handle(
				GetFantasyProvidersByIdsQuery request,
				CancellationToken cancellationToken)
			{
				return await _context.FantasyProviders
					.AsNoTracking()
					.Where(provider => request.FantasyProviderIds.Contains(provider.Id))
					.ToListAsync();
			}
		}
	}
}
