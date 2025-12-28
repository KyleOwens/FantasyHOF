using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Types
{
    public class League
    {
        public int Id { get; private set; }
        public Guid? UserId { get; private set; }

        public required FantasyProviderId FantasyProviderId { get; init; }
        public required string ProviderLeagueId { get; init; }
        public required SportId SportId { get; init; }

        public List<LeagueSeason> Seasons { get; set; } = new();
        public FantasyProvider FantasyProvider { get; private set; } = null!;
        public Sport Sport { get; private set; } = null!;
    }
}
