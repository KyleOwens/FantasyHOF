using FantasyHOF.Application.Authentication;
using FantasyHOF.Application.Exceptions;
using FantasyHOF.Application.Types.Mutations;
using FantasyHOF.Domain.Entities;
using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Mutations
{
    public sealed record DeleteUserLeagueMutation(int LeagueId) : IRequest<DeleteUserLeagueMutationPayload>
    {
        public sealed class DeleteUserLeagueMutationHandler(FantasyHOFDBContext database, ICurrentUserService currentUser) : IRequestHandler<DeleteUserLeagueMutation, DeleteUserLeagueMutationPayload>
        {
            public async Task<DeleteUserLeagueMutationPayload> Handle(DeleteUserLeagueMutation request, CancellationToken cancellationToken)
            {
                if (!currentUser.IsAuthenticated) throw new ForbiddenException();

                Guid userId = await currentUser.GetUserIdAsync(cancellationToken);

                User user = await database.Users
                    .Include(x => x.Leagues)
                    .SingleAsync(x => x.Id == userId);

                bool success = user.RemoveLeagueIfExists(request.LeagueId);
                if (!success) throw new NotFoundException(nameof(League), request.LeagueId);

                //await database.SaveChangesAsync();

                return new(request.LeagueId);
            }
        }
    }
}
