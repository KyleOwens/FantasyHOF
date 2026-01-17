using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.MatchupTypeQueries
{
    public sealed record GetMatchupTypesByIdsQuery(IEnumerable<MatchupTypeId> MatchupTypeIds)
        : IRequest<IEnumerable<MatchupType>>
    {
        public sealed class GetMatchupTypesByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetMatchupTypesByIdsQuery, IEnumerable<MatchupType>>
        {
            public async Task<IEnumerable<MatchupType>> Handle(
                GetMatchupTypesByIdsQuery request,
                CancellationToken ct)
            {
                return await database.MatchupTypes
                    .AsNoTracking()
                    .Where(type => request.MatchupTypeIds.Contains(type.Id))
                    .ToListAsync(ct);
            }
        }
    }
}