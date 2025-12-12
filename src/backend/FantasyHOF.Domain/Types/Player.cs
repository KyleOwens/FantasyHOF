namespace FantasyHOF.Domain.Types
{
    public class Player
    {
        public int Id { get; private set; }

        public required FantasyProviderId ProviderId { get; init; }
        public required int ProviderPlayerId { get; init; }
        public required string FirstName { get; init; }
        public required string FullName { get; init; }

        public FantasyProvider Provider { get; private set; } = null!;
    }
}