using FantasyHOF.Application.Queries.LeagueSeasonQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.GraphQL.Types.DataLoaderDefinitions;
using FantasyHOF.GraphQL.Types.DataLoaders;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType(typeof(LeagueSeason))]
    public class LeagueSeasonTypeExtension
    {
        [ID<League>]
        public int LeagueId([Parent] LeagueSeason season) => season.LeagueId;

        public async Task<LeagueSeasonSettings> GetSettingsAsync(
            [Parent] LeagueSeason season,
            ILeagueSeasonSettingsByLeagueSeasonIdsDataLoader leagueSeasonSettings,
            CancellationToken cancellationToken)
        {
            return await leagueSeasonSettings.LoadRequiredAsync(season.Id, cancellationToken);
        }

        public async Task<IEnumerable<LeagueSeasonMember>> GetMembersAsync(
            [Parent] LeagueSeason season,
            ILeagueSeasonMembersByLeagueSeasonIdDataLoader seasonMembers,
            CancellationToken cancellationToken)
        {
            return await seasonMembers.LoadAsync(season.Id, cancellationToken) ?? [];
        }

        public static async Task<LeagueSeason?> GetLeagueSeasonAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueSeasonByIdQuery(id), cancellationToken);
        }
    }
}
