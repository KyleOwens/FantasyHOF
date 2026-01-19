using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Interfaces;

namespace FantasyHOF.Domain.Entities
{
    public class League : ITimestamped
    {
        public int Id { get; private set; }
        public Guid UserId { get; set; }

        public required FantasyProviderId FantasyProviderId { get; init; }
        public required string ProviderLeagueId { get; init; }
        public required SportId SportId { get; init; }
        public required string CurrentLeagueName { get; init; }
        public required int CurrentLeagueYear { get; init; }

        public List<LeagueSeason> Seasons { get; set; } = [];
        public List<LeagueMember> LeagueMembers { get; private set; } = [];
        public FantasyProvider FantasyProvider { get; private set; } = null!;
        public Sport Sport { get; private set; } = null!;

        public DateTimeOffset CreatedAt { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
    }
}
