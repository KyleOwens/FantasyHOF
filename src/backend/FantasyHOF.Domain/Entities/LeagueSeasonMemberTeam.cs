using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonMemberTeam
    {
        public int LeagueSeasonId { get; private set; }
        public int MemberId { get; private set; }
        public int TeamId { get; private set; }

        public LeagueSeasonMember Owner { get; private set; } = null!;
        public Team Team { get; private set; } = null!;

        public LeagueSeasonMemberTeamId Id => new(LeagueSeasonId, MemberId, TeamId);

        public void SetTeam(Team team)
        {
            Team = team;
        }
    }
}
