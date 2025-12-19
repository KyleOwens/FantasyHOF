using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Types
{
    public class TeamMatchup
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }
        public int? OpponentTeamId { get; private set; }

        public required int Week { get; init; }
        public required decimal Score { get; init; }
        public required MatchupOutcomeId MatchupOutcomeId { get; init; }
        public required MatchupTypeId MatchupTypeId { get; init; }

        public Team? Opponent { get; set; } = null!;
        public MatchupOutcome MatchupOutcome { get; set; } = null!;
        public MatchupType MatchupType { get; set; } = null!;
        public List<MatchupRosterSpot> MatchupRosterSpots { get; set; } = null!;
    }
}