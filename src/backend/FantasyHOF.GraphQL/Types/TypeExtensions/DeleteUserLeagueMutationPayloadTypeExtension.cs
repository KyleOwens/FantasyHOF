using FantasyHOF.Application.Types.Mutations;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [ExtendObjectType<DeleteUserLeagueMutationPayload>]
    internal class DeleteUserLeagueMutationPayloadTypeExtension
    {
        [ID<League>]
        public int LeagueId([Parent] DeleteUserLeagueMutationPayload payload) => payload.LeagueId;
    }
}
