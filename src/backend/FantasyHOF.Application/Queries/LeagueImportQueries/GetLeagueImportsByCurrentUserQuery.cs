using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Application.Authentication;

namespace FantasyHOF.Application.Queries.LeagueImportQueries
{
    public sealed record GetLeagueImportsByCurrentUserQuery : IRequest<List<LeagueImport>>
    {
        public sealed class GetLeagueImportsByCurrentUserQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser) : IRequestHandler<GetLeagueImportsByCurrentUserQuery, List<LeagueImport>>
        {
            public async Task<List<LeagueImport>> Handle(GetLeagueImportsByCurrentUserQuery request, CancellationToken cancellationToken)
            {
                if (!currentUser.IsAuthenticated) return [];

                Guid userId = await currentUser.GetUserIdAsync();

                return await database.LeagueImports
                    .Where(x => x.UserId == userId)
                    .Where(x => x.StatusId != LeagueImportStatusId.Completed)
                    .ToListAsync(cancellationToken);
            }
        }
    }
}
