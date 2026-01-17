using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Application.Types.Exceptions;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;

namespace FantasyHOF.Application.Queries.LeagueImportQueries
{
    public sealed record GetLeagueImportsByCurrentUserQuery
        : IRequest<IQueryable<LeagueImport>>
    {
        public sealed class GetLeagueImportsByCurrentUserQueryHandler(FantasyHOFDBContext database, ICurrentUserService currentUser)
            : IRequestHandler<GetLeagueImportsByCurrentUserQuery, IQueryable<LeagueImport>>
        {
            public async Task<IQueryable<LeagueImport>> Handle(GetLeagueImportsByCurrentUserQuery request, CancellationToken ct)
            {
                if (!currentUser.IsAuthenticated) throw new ForbiddenException();

                Guid userId = await currentUser.GetUserIdAsync();

                return database.LeagueImports
                    .Where(x => x.UserId == userId)
                    .Where(x => x.StatusId != LeagueImportStatusId.Completed)
                    .OrderBy(x => x.Id);
            }
        }
    }
}
