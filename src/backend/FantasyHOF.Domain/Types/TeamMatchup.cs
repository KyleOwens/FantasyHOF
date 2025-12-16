namespace FantasyHOF.Domain.Types
{
    public class TeamMatchup
    {
        public int Id { get; private set; }
        public int TeamId { get; private set; }
        public int? OpponentTeamId { get; private set; }

        public required int Week { get; init; }
        public required decimal Score { get; init; }

        public Team? Opponent { get; set; } = null!;
        public List<MatchupRosterSpot> MatchupRosterSpots { get; set; } = null!;
    }
}