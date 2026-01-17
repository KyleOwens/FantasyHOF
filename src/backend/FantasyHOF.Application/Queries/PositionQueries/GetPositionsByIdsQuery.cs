using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.PositionQueries
{
    public sealed record GetPositionsByIdsQuery(IEnumerable<PositionId> PositionIds)
        : IRequest<IEnumerable<Position>>
    {
        public sealed class GetPositionsByIdsQueryHandler(FantasyHOFDBContext database)
            : IRequestHandler<GetPositionsByIdsQuery, IEnumerable<Position>>
        {
            public async Task<IEnumerable<Position>> Handle(
                GetPositionsByIdsQuery request,
                CancellationToken ct)
            {
                return await database.Positions
                    .AsNoTracking()
                    .Where(position => request.PositionIds.Contains(position.Id))
                    .ToListAsync(ct);
            }
        }
    }
}