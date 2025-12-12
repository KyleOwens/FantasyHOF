namespace FantasyHOF.Domain.Types
{
    public class TeamMatchup
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }

        public required int Week { get; init; }
        public required int Score { get; init; }
        public required Team Opponent { get; init; }
        public required List<MatchupRosterSpot> MatchupRosterSpots { get; init; }
    }
}