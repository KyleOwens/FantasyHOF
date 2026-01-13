using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.FantasyProviderQueries
{
    public sealed record GetAllFantasyProvidersQuery : IRequest<List<FantasyProvider>>
    {
        public sealed class GetAllFantasyProvidersQueryHandler(FantasyHOFDBContext database) : IRequestHandler<GetAllFantasyProvidersQuery, List<FantasyProvider>>
        {
            public async Task<List<FantasyProvider>> Handle(GetAllFantasyProvidersQuery request, CancellationToken cancellationToken)
            {
                return await database.FantasyProviders.ToListAsync();
            }
        }
    }
}
