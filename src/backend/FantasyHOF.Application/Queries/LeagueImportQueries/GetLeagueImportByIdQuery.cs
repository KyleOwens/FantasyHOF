using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.LeagueImportQueries
{
    public record GetLeagueImportByIdQuery(int LeagueImportId) : IRequest<LeagueImport?>
    {
        public class GetLeagueImportByIdQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetLeagueImportByIdQuery, LeagueImport?>
        {
            public async Task<LeagueImport?> Handle(GetLeagueImportByIdQuery request, CancellationToken cancellationToken)
            {
                return await database.LeagueImports.SingleAsync(x => x.Id == request.LeagueImportId);
            }
        }
    }
}