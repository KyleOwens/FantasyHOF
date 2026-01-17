using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.FantasyProviderQueries
{
    public sealed record GetFantasyProvidersByIdsQuery(IEnumerable<FantasyProviderId> FantasyProviderIds)
        : IRequest<IEnumerable<FantasyProvider>>
    {
        public sealed class GetFantasyProvidersByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetFantasyProvidersByIdsQuery, IEnumerable<FantasyProvider>>
        {
            public async Task<IEnumerable<FantasyProvider>> Handle(
                GetFantasyProvidersByIdsQuery request,
                CancellationToken cancellationToken)
            {
                return await database.FantasyProviders
                    .AsNoTracking()
                    .Where(provider => request.FantasyProviderIds.Contains(provider.Id))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
