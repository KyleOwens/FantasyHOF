namespace FantasyHOF.Domain.Types
{
    public class FantasyTeamSeasonStats
    {
        public required int Wins { get; set; }
        public required int Losses { get; set; }
        public required int Ties { get; set; }
        public required double WinPercentage { get; set; }
        public required float PointsAgainst { get; set; }
        public required float PointsFor { get; set; }
    }
}