using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class MatchupRosterSpot
    {
        public int Id { get; private set; }
        public int MatchupTeamDetailsId { get; set; }
        public int PlayerId { get; set; }

        public required Guid UserId { get; init; }
        public required int ProviderPlayerId { get; init; }
        public required PositionId PositionId { get; init; }
        public required decimal PointsScored { get; init; }

        public Player Player { get; private set; } = null!;
        public Position Position { get; private set; } = null!;
        public List<AccumulatedStat> AccumulatedStats { get; private set; } = null!;

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public void SetAccumulatedStats(List<AccumulatedStat> accumulatedStats)
        {
            AccumulatedStats = accumulatedStats;
        }
    }
}
