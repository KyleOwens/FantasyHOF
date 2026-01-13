using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class FantasyMember
    {
        public int Id { get; private set; }

        public required FantasyProviderId FantasyProviderId { get; init; }
        public required string ProviderMemberId { get; init; }
        public required string DisplayName { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; set; }

        public FantasyProvider FantasyProvider { get; private set; } = null!;

        public string FullName => FirstName + " " + LastName;
    }
}
