namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonSettings
    {
        public int Id { get; set; }
        public int LeagueSeasonId { get; set; }

        public required string LeagueName { get; set; }

        public LeagueSeasonScheduleSettings ScheduleSettings { get; private set; } = null!;
        public LeagueSeasonScoringSettings ScoringSettings { get; private set; } = null!;

        public void SetScheduleSettings(LeagueSeasonScheduleSettings scheduleSettings)
        {
            ScheduleSettings = scheduleSettings;
        }

        public void SetScoringSettings(LeagueSeasonScoringSettings scoringSettings)
        {
            ScoringSettings = scoringSettings;
        }
    }
}
