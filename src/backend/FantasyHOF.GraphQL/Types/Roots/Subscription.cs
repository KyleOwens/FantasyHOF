using FantasyHOF.Domain.Entities;
using FantasyHOF.Infrastructure.ServiceDefinitions;
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
            CancellationToken ct)
        {
            Guid userId = await currentUser.GetUserIdAsync(ct);
            return await receiver.SubscribeAsync<LeagueImport>(
                $"{nameof(LeagueImport)}_{userId}",
                ct);
        }

        [Authorize]
        [Subscribe(With = nameof(SubscribeToLeagueImportProgress))]
        public LeagueImport LeagueImportProgress(
            [EventMessage] LeagueImport import) => import;
    }
}
