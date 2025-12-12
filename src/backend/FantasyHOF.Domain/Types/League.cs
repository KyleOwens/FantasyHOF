namespace FantasyHOF.Domain.Types
{
    public enum FantasyProviderId
    {
        ESPN = 1,
    }

    public enum SportId
    {
        Football = 1
    }
    
    public class League
    {
        public int Id { get; private set; }

        public required FantasyProviderId FantasyProviderId { get; init; }
        public required string ProviderLeagueId { get; init; }
        public required SportId SportId { get; init; }
        public required List<LeagueSeason> Seasons { get; init; }

        public FantasyProvider FantasyProvider { get; private set; } = null!;
        public List<LeagueSeasonMember> Members { get; private set; } = null!;
    }
}
