using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class FantasyProvider
    {
        public FantasyProviderId Id { get; private set; }
        public string Name { get; private set; } = null!;
        public string LogoURL { get; private set; } = null!;

        protected FantasyProvider() { }

        public FantasyProvider(FantasyProviderId id, string name, string logoURL)
        {
            Id = id;
            Name = name;
            LogoURL = logoURL;
        }
    }
}