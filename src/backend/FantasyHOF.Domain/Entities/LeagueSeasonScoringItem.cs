using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonScoringItem
    {
        public int Id { get; private set; }
        public int LeagueSeasonId { get; set; }

        public required string UserId { get; init; }
        public required StatId StatId { get; init; }
        public required decimal Points { get; init; }

        public Stat Stat { get; private set; } = null!;
    }
}