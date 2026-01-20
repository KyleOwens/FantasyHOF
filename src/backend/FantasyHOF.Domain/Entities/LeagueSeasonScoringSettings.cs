namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonScoringSettings
    {
        public int Id { get; private set; }
        public int LeagueSeasonId { get; set; }

        public required Guid UserId { get; init; }
        public required int HomeTeamBonusPoints { get; init; }
        public required string MatchupTieRule { get; init; }
        public required int MatchupTieRuleBy { get; init; }
        public required string PlayerRankType { get; init; }
        public required int PlayoffHomeTeamBonusPoints { get; init; }
        public required string PlayoffMatchupTieRule { get; init; }
        public required int PlayoffMatchupTieRuleBy { get; init; }
        public required string ScoringType { get; init; }

        public List<LeagueSeasonScoringItem> ScoringItems { get; private set; } = null!;
    }
}