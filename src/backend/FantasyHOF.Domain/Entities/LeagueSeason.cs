namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeason
    {
        public int Id { get; private set; }
        public int LeagueId { get; private set; }

        public required int Year { get; init; }
        public LeagueSeasonSettings Settings { get; private set; } = null!;
        public List<LeagueSeasonMember> Members { get; private set; } = null!;

        public void SetSettings(LeagueSeasonSettings settings)
        {
            Settings = settings;
        }

        public void SetMembers(List<LeagueSeasonMember> seasonMembers)
        {
            Members = seasonMembers;
        }
    }
}
