namespace FantasyHOF.Domain.Types
{
    public class FantasyProvider
    {
        public FantasyProviderId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected FantasyProvider() { }

        public FantasyProvider(FantasyProviderId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}