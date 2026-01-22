using FantasyHOF.Application.Types.Exceptions;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueByIdQuery(int LeagueId)
        : IRequest<League>;

    public sealed class GetLeagueByIdQueryHandler(FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueByIdQuery, League>
    {
        public async Task<League> Handle(GetLeagueByIdQuery request, CancellationToken ct)
        {
            return await database.Leagues.FirstOrDefaultAsync(x => x.Id == request.LeagueId, ct) ??
                throw new NotFoundException(nameof(League), request.LeagueId);
        }
    }
}
