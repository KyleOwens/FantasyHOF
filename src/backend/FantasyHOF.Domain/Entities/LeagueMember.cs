using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueMember
    {
        public LeagueMemberId Id => new(LeagueId, MemberId);

        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }

        public required int Firstyear { get; init; }
        public required int LearYear { get; init; }
        public required int Tenure { get; init; }

        public League League { get; init; } = null!;
        public FantasyMember Member { get; init; } = null!;
    }
}
