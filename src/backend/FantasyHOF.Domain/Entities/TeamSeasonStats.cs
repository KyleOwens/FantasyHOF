namespace FantasyHOF.Domain.Entities
{
    public class TeamSeasonStats
    {
        public int Id { get; private set; }
        public int TeamId { get; set; }

        public required int Wins { get; set; }
        public required int Losses { get; set; }
        public required int Ties { get; set; }
        public required decimal WinPercentage { get; set; }
        public required decimal PointsAgainst { get; set; }
        public required decimal PointsFor { get; set; }
    }
}