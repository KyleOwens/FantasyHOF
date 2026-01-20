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
        [Authorize]
        public async ValueTask<ISourceStream<LeagueImport>> SubscribeToLeagueImportProgress(
            ICurrentUserService currentUser,
            ITopicEventReceiver receiver,
            CancellationToken ct)
        {
            return await receiver.SubscribeAsync<LeagueImport>(
                $"{nameof(LeagueImport)}_{currentUser.Id}",
                ct);
        }

        [Authorize]
        [Subscribe(With = nameof(SubscribeToLeagueImportProgress))]
        public LeagueImport LeagueImportProgress(
            [EventMessage] LeagueImport import) => import;
    }
}
