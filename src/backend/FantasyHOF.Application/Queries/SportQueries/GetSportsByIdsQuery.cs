using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.SportQueries
{
    public sealed record GetSportsByIdsQuery(IEnumerable<SportId> SportIds)
        : IRequest<IEnumerable<Sport>>
    {
        public sealed class GetSportsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetSportsByIdsQuery, IEnumerable<Sport>>
        {
            public async Task<IEnumerable<Sport>> Handle(
                GetSportsByIdsQuery request,
                CancellationToken ct)
            {
                return await database.Sports
                    .AsNoTracking()
                    .Where(sport => request.SportIds.Contains(sport.Id))
                    .ToListAsync(ct);
            }
        }
    }
}