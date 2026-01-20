namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeason
    {
        public int Id { get; private set; }
        public int LeagueId { get; set; }

        public required Guid UserId { get; init; }
        public required int Year { get; init; }
        public LeagueSeasonSettings Settings { get; private set; } = null!;
        public List<LeagueSeasonMember> Members { get; private set; } = null!;
    }
}
