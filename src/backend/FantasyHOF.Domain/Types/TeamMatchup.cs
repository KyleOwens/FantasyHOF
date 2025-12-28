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

        public Team? Opponent { get; private set; } = null!;
        public MatchupOutcome MatchupOutcome { get; private set; } = null!;
        public MatchupType MatchupType { get; private set; } = null!;
        public List<MatchupRosterSpot> MatchupRosterSpots { get; private set; } = null!;

        public void SetOpponent(Team opponent)
        {
            Opponent = opponent;
        }

        public void SetMatchupOutcome(MatchupOutcome matchupOutcome)
        {
            MatchupOutcome = matchupOutcome;
        }

        public void SetMatchupType(MatchupType matchupType)
        {
            MatchupType = matchupType;
        }

        public void SetMatchupRosterSpots(List<MatchupRosterSpot> matchupRosterSpots)
        {
            MatchupRosterSpots = matchupRosterSpots;
        }
    }
}