using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueMember
    {
        public LeagueMemberId Id => new(LeagueId, MemberId);

        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }

        public required int Firstyear { get; init; }
        public required int LastYear { get; init; }
        public required int Tenure { get; init; }
        public required string CurrentTeamLogoURL { get; init; }

        public League League { get; private set; } = null!;
        public FantasyMember Member { get; private set; } = null!;

        public void Setleague(League league)
        {
            League = league;
        }

        public void SetMember(FantasyMember member)
        {
            Member = member;
        }
    }
}
