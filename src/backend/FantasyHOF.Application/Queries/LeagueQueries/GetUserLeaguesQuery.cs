using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetUserLeaguesQuery : IRequest<List<League>>
    {
        public sealed class GetUserLeaguesQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser) : IRequestHandler<GetUserLeaguesQuery, List<League>>
        {
            public async Task<List<League>> Handle(GetUserLeaguesQuery request, CancellationToken cancellationToken)
            {
                if (!currentUser.IsAuthenticated) return [];

                Guid currentUserId = await currentUser.GetUserIdAsync();

                return await database.Leagues
                    .Where(x => x.UserId == currentUserId)
                    .ToListAsync();
            }
        }
    }
}
