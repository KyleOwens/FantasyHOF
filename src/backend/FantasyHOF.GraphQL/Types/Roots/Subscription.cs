using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Domain.Entities;
using HotChocolate.Authorization;
using HotChocolate.Execution;
using HotChocolate.Subscriptions;

namespace FantasyHOF.GraphQL.Types.Roots
{
    [SubscriptionType]
    public class Subscription
    {
        // This sets up the subscription stream
        public async ValueTask<ISourceStream<LeagueImport>> SubscribeToLeagueImportProgress(
            ICurrentUserService currentUser,
            ITopicEventReceiver receiver,
            CancellationToken cancellationToken)
        {
            Guid userId = await currentUser.GetUserIdAsync();
            return await receiver.SubscribeAsync<LeagueImport>(
                $"{nameof(LeagueImport)}_{userId}",
                cancellationToken);
        }

        [Authorize]
        [Subscribe(With = nameof(SubscribeToLeagueImportProgress))]
        public LeagueImport LeagueImportProgress(
            [EventMessage] LeagueImport import) => import;
    }
}
