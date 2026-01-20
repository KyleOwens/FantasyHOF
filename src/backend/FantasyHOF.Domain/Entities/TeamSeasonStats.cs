namespace FantasyHOF.Domain.Entities
{
    public class TeamSeasonStats
    {
        public int Id { get; private set; }
        public int TeamId { get; set; }

        public required Guid UserId { get; init; }
        public required int Wins { get; init; }
        public required int Losses { get; init; }
        public required int Ties { get; init; }
        public required decimal WinPercentage { get; init; }
        public required decimal PointsAgainst { get; init; }
        public required decimal PointsFor { get; init; }
    }
}