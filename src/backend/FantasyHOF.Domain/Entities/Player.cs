using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class Player
    {
        public int Id { get; private set; }

        public required FantasyProviderId ProviderId { get; init; }
        public required int ProviderPlayerId { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; init; }
        public required string FullName { get; init; }

        public FantasyProvider Provider { get; private set; } = null!;

        public string PlayerImageURL(int width = 96, int height = 70)
        {
            return ProviderId switch
            {
                FantasyProviderId.ESPN => $"https://a.espncdn.com/combiner/i?img=/i/headshots/nfl/players/full/{ProviderPlayerId}.png&w={width}&h={height}",
                _ => ""
            };
        }
    }
}