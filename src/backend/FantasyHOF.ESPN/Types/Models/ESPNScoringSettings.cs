namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNScoringSettings
    {
        public bool AllowOutOfPositionScoring { get; set; }
        public int HomeTeamBonus { get; set; }
        public string MatchupTieRule { get; set; } = default!;
        public int MatchupTieRuleBy { get; set; }
        public string PlayerRankType { get; set; } = default!;
        public int PlayoffHomeTeamBonus { get; set; }
        public string PlayoffMatchupTieRule { get; set; } = default!;
        public int PlayoffMatchupTieRuleBy { get; set; }
        public string ScoringType { get; set; } = default!;
        public List<ESPNScoringItem> ScoringItems { get; set; } = [];
    }
}