namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonScoringSettings
    {
        public required int HomeTeamBonusPoints { get; set; }
        public required string MatchupTieRule { get; set; }
        public required int MatchupTieRuleBy { get; set; }
        public required string PlayerRankType { get; set; }
        public required int PlayoffHomeTeamBonusPoints { get; set; }
        public required string PlayoffMatchupTieRule { get; set; }
        public required int PlayoffMatchupTieRuleBy { get; set; }
        public required string ScoringType { get; set; }
        public required List<FantasyScoringItem> ScoringItems { get; set; }
    }
}