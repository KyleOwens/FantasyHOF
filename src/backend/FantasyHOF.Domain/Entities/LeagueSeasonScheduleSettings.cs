namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonScheduleSettings
    {
        public int Id { get; private set; }
        public int LeagueSeasonId { get; set; }

        public required int MatchupCount { get; set; }
        public required int MatchupLength { get; set; }
        public required int PlayoffMatchupLength { get; set; }
        public required int PlayoffTeamCount { get; set; }
        public required bool VariablePlayoffMatchupLength { get; set; }
    }
}