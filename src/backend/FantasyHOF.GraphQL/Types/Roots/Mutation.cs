using FantasyHOF.Application.Mutations;
using FantasyHOF.Application.QueryTypes;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN.Errors;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.Infrastructure.Authentication;
using HotChocolate.Authorization;
using HotChocolate.Subscriptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.Roots
{
    [MutationType]
    public static class Mutation
    {
        [Error(typeof(ESPNAuthenticationException))]
        [Error(typeof(ESPNHttpException))]
        [Error(typeof(ESPNLeagueInvalidException))]
        [Error(typeof(ESPNNoActiveYearsException))]
        [Error(typeof(ESPNInvalidYearException))]
        [Authorize]
        public static async Task<AddLeagueMutationPayload> AddESPNLeagueToUserAsync(
            string leagueId, 
            string swid, 
            string espnS2Id, 
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(
                new AddESPNLeagueForUserCommand(
                    new ESPNLeagueCredentials(
                        leagueId,
                        swid,
                        espnS2Id)), 
                cancellationToken);
        }

        [Authorize]
        public static async Task<bool> PublishTestMessage(int progress, ICurrentUserService currentUser, ITopicEventSender eventSender)
        {
            await eventSender.SendAsync($"{nameof(LeagueImport)}_{await currentUser.GetUserIdAsync()}", new LeagueImport
            {
                Progress = progress,
                ProviderId = Domain.Enums.FantasyProviderId.ESPN,
                ProviderleagueId = "test lol",
                StatusId = Domain.Enums.LeagueImportStatusId.SavingData,
                UserId = await currentUser.GetUserIdAsync()
            });

            return true;
        }
    }
}
