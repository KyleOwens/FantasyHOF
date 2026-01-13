using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.QueryTypes.Records;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType(typeof(League))]
    public class LeagueTypeExtension
    {
        [ID<FantasyProvider>]
        public int FantasyProviderId([Parent] League league) => (int)league.FantasyProviderId;

        public async Task<IEnumerable<LeagueSeason>> GetSeasonsAsync(
            [Parent] League league,
            ILeagueSeasonsByLeagueIdsDataLoader leagueSeasons,
            CancellationToken cancellationToken)
        {
            return await leagueSeasons.LoadAsync(league.Id, cancellationToken) ?? [];
        }

        public async Task<IEnumerable<LeagueMember>> GetMembersAsync(
            [Parent] League league,
            ILeagueMembersByLeagueIdsDataLoader leagueMembers,
            CancellationToken cancellationToken)
        {
            return await leagueMembers.LoadAsync(league.Id) ?? [];
        }

        public async Task<FantasyProvider> GetFantasyProviderAsync(
            [Parent] League league,
            IFantasyProvidersByIdsDataLoader providers,
            CancellationToken cancellationToken)
        {
            return await providers.LoadRequiredAsync(league.FantasyProviderId, cancellationToken);
        }

        public async Task<Sport> GetSportAsync(
            [Parent] League league,
            ISportsByIdsDataLoader sports,
            CancellationToken cancellationToken)
        {
            return await sports.LoadRequiredAsync(league.SportId, cancellationToken);
        }

        public async Task<LeagueRecordSummary?> GetRecordSummaryAsync(
            [Parent] League league,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueRecordSummaryQuery(league.Id), cancellationToken);
        }

        public async Task<IEnumerable<RecordDetails>> GetRecordDetailsAsync(
            [Parent] League league,
            RecordTypeId recordType,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueSingleRecordDetailsQuery(league.Id, recordType));
        }

        public static async Task<League?> GetLeagueAsync(
            int id,
            ILeaguesByIdsDataLoader leagues,
            CancellationToken cancellationToken)
        {
            return await leagues.LoadAsync(id, cancellationToken);
        }
    }
}
