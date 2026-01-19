using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonMember
    {
        public int LeagueSeasonId { get; set; }
        public int MemberId { get; set; }

        public required bool IsLeagueCreator { get; init; }
        public required bool IsLeagueManager { get; init; }

        public required string ProviderMemberId { get; init; }

        public FantasyMember Member { get; private set; } = null!;
        public List<LeagueSeasonMemberTeam> Teams { get; private set; } = null!;

        public LeagueSeasonMemberId Id => new(LeagueSeasonId, MemberId);

        public void SetMember(FantasyMember member)
        {
            Member = member;
        }

        public void SetTeams(List<LeagueSeasonMemberTeam> teams)
        {
            Teams = teams;
        }
    }
}
