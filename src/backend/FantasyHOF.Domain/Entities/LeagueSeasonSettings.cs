namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonSettings
    {
        public int Id { get; set; }
        public int LeagueSeasonId { get; set; }

        public required string UserId { get; init; }
        public required string LeagueName { get; init; }

        public LeagueSeasonScheduleSettings ScheduleSettings { get; private set; } = null!;
        public LeagueSeasonScoringSettings ScoringSettings { get; private set; } = null!;
    }
}
