namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNScheduleSettings
    {
        public int MatchupPeriodCount { get; set; }
        public int MatchupPeriodLength { get; set; }
        public int PlayoffMatchypPeriodLength { get; set; }
        public int PlayoffTeamCount { get; set; }
        public bool VariablePlayoffMatchypPeriodLength { get; set; }
    }
}