namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonScoringSettings
    {
        public int Id { get; private set; }
        public int LeagueSeasonId { get; private set; }

        public required int HomeTeamBonusPoints { get; set; }
        public required string MatchupTieRule { get; set; }
        public required int MatchupTieRuleBy { get; set; }
        public required string PlayerRankType { get; set; }
        public required int PlayoffHomeTeamBonusPoints { get; set; }
        public required string PlayoffMatchupTieRule { get; set; }
        public required int PlayoffMatchupTieRuleBy { get; set; }
        public required string ScoringType { get; set; }

        public List<LeagueSeasonScoringItem> ScoringItems { get; set; } = null!;
    }
}