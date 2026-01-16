using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities.Views
{
    public class PlayerAggregationData
    {
        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }
        public int Year { get; private set; }
        public int Week { get; private set; }
        public decimal PointsScored { get; private set; }
        public int PlayerId { get; private set; }
        public PositionId PositionId { get; private set; }

        public LeagueMember MemberDetails { get; private set; } = null!;
        public Player Player { get; private set; } = null!;
        public Position Position { get; private set; } = null!;
    }
}
