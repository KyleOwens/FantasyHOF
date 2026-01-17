using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Application.Types.Exceptions;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueByIdQuery(int LeagueId)
        : IRequest<League>;

    public sealed class GetLeagueByIdQueryHandler(ICurrentUserService currentUser, FantasyHOFDBContext database)
        : IRequestHandler<GetLeagueByIdQuery, League>
    {
        public async Task<League> Handle(GetLeagueByIdQuery request, CancellationToken cancellationToken)
        {
            if (!currentUser.IsAuthenticated) throw new ForbiddenException();

            Guid userId = await currentUser.GetUserIdAsync(cancellationToken);

            User user = await database.Users
                .Include(x => x.Leagues)
                .SingleAsync(x => x.Id == userId, cancellationToken);

            return user.Leagues.FirstOrDefault(x => x.Id == request.LeagueId) ??
                throw new NotFoundException(nameof(League), request.LeagueId);
        }
    }
}
