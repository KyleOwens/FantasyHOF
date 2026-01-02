using FantasyHOF.Application.Mappers;
using FantasyHOF.Application.Queries.ESPNQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.Infrastructure.Authentication;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mutations
{
    public sealed record AddESPNLeagueForUserCommand(ESPNLeagueCredentials LeagueCredentials) : IRequest<League>
    {
        public sealed class AddESPNLeagueForUserCommandHandler(ICurrentUserService currentUser, IMediator mediator, FantasyHOFDBContext database, IStatAggregator statAggregator) : IRequestHandler<AddESPNLeagueForUserCommand, League>
        {
            public async Task<League> Handle(AddESPNLeagueForUserCommand request, CancellationToken cancellationToken)
            {
                Guid authenticatedUserId = await currentUser.GetUserIdAsync(cancellationToken);
                User user = await database.Users
                    .Include(user => user.Leagues)
                    .SingleAsync(user => user.Id == authenticatedUserId, cancellationToken);

                user.RemoveLeagueIfExists(FantasyProviderId.ESPN, request.LeagueCredentials.LeagueId);

                League newLeague = await mediator.Send(new GetESPNLeagueQuery(request.LeagueCredentials), cancellationToken);
                user.AddLeague(newLeague);
                await database.SaveChangesAsync(cancellationToken);

                database.LeagueMemberAggregateStats.AddRange(statAggregator.AggregateMemberStats(newLeague));

                await database.SaveChangesAsync(cancellationToken);

                return newLeague;
            }
        }
    }
}
