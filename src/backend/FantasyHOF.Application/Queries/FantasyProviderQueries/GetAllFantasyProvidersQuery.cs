using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
