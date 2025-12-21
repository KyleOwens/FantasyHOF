
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;

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
				return _context.FantasyProviders
					.Where(provider => request.FantasyProviderIds.Contains(provider.Id));
			}
		}
	}
}
