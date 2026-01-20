using FantasyHOF.Domain.ComplexIds;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueMember
    {
        public LeagueMemberId Id => new(LeagueId, MemberId);

        public int LeagueId { get; set; }
        public int MemberId { get; set; }

        public required Guid UserId { get; init; }
        public required int Firstyear { get; init; }
        public required int LastYear { get; init; }
        public required int Tenure { get; init; }
        public required string CurrentTeamName { get; init; }
        public required string CurrentTeamLogoURL { get; init; }

        public League League { get; private set; } = null!;
        public FantasyMember Member { get; private set; } = null!;
    }
}
