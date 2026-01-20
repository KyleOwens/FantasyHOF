using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class MatchupTeamDetails
    {
        public int Id { get; private set; }
        public int TeamId { get; set; }

        public required string UserId { get; init; }
        public required decimal Score { get; init; }
        public required MatchupOutcomeId MatchupOutcomeId { get; init; }

        public Team Team { get; private set; } = null!;
        public MatchupOutcome Outcome { get; private set; } = null!;
        public List<MatchupRosterSpot> MatchupRosterSpots { get; private set; } = null!;

        public void SetMatchupRosterSpots(List<MatchupRosterSpot> rosterSpots)
        {
            MatchupRosterSpots = rosterSpots;
        }
    }
}
