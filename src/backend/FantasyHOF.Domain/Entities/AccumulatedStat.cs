using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class AccumulatedStat
    {
        public int Id { get; private set; }
        public int MatchupRosterSpotId { get; set; }

        public required StatId StatId { get; init; }
        public required decimal StatValue { get; init; }
        public required decimal PointsScored { get; init; }

        public Stat Stat { get; private set; } = null!;
    }
}
