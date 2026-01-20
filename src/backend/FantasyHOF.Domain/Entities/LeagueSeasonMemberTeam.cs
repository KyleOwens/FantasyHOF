using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonMemberTeam
    {
        public int LeagueSeasonId { get; set; }
        public int MemberId { get; set; }
        public int TeamId { get; set; }

        public required Guid UserId { get; init; }
        public required string ProviderMemberId { get; init; }
        public required int ProviderTeamId { get; init; }
        public LeagueSeasonMember Owner { get; private set; } = null!;
        public Team Team { get; private set; } = null!;

        public LeagueSeasonMemberTeamId Id => new(LeagueSeasonId, MemberId, TeamId);
    }
}
