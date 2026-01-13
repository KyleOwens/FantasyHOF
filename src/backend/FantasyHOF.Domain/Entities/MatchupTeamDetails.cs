using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class MatchupTeamDetails
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }

        public required decimal Score { get; init; }
        public required MatchupOutcomeId MatchupOutcomeId { get; init; }

        public Team Team { get; private set; } = null!;
        public MatchupOutcome Outcome { get; private set; } = null!;
        public List<MatchupRosterSpot> MatchupRosterSpots { get; private set; } = null!;

        public void SetTeam(Team team)
        {
            Team = team;
        }

        public void SetMatchupRosterSpots(List<MatchupRosterSpot> rosterSpots)
        {
            MatchupRosterSpots = rosterSpots;
        }
    }
}
