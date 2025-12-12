namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonScheduleSettings
    {
        public required int MatchupCount { get; set; }
        public required int MatchupLength { get; set; }
        public required int PlayoffMatchupLength { get; set; }
        public required int PlayoffTeamCount { get; set; }
        public required bool VariablePlayoffMatchupLength { get; set; }
    }
}