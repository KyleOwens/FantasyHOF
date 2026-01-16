using FantasyHOF.Application.Queries.LeagueImportQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<LeagueImport>]
    internal class LeagueImportTypeExtension
    {
        public async Task<User> GetUserAsync(
            [Parent] LeagueImport import,
            IUsersByIdsDataLoader users,
            CancellationToken cancellationToken)
        {
            return await users.LoadRequiredAsync(import.UserId, cancellationToken);
        }

        public async Task<FantasyProvider> GetProviderAsync(
            [Parent] LeagueImport import,
            IFantasyProvidersByIdsDataLoader providers,
            CancellationToken cancellationToken)
        {
            return await providers.LoadRequiredAsync(import.ProviderId, cancellationToken);
        }

        public async Task<LeagueImportStatus> GetStatusAsync(
            [Parent] LeagueImport import,
            ILeagueImportStatusesByIdsDataLoader statuses,
            CancellationToken cancellationToken)
        {
            return await statuses.LoadRequiredAsync(import.StatusId, cancellationToken);
        }

        public async Task<League?> GetLeagueAsync(
            [Parent] LeagueImport import,
            ILeaguesByIdsDataLoader leagues,
            CancellationToken cancellationToken)
        {
            if (import.LeagueId == null) return null;

            return await leagues.LoadAsync(import.LeagueId.Value, cancellationToken);
        }

        public static async Task<LeagueImport?> GetLeagueImportAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueImportByIdQuery(id), cancellationToken);
        }
    }
}
