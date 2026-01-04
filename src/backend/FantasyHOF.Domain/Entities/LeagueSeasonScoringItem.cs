using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonScoringItem
    {
        public int Id { get; private set; }
        public int LeagueSeasonId { get; private set; }
        
        public required StatId StatId { get; init; }
        public required decimal Points { get; init; }

        public Stat Stat { get; private set; } = null!;
    }
}