using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.ServiceDefinitions;
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
                return database.LeagueImports
                    .Where(x => x.UserId == currentUser.Id)
                    .Where(x => x.StatusId != LeagueImportStatusId.Completed)
                    .OrderBy(x => x.Id);
            }
        }
    }
}
