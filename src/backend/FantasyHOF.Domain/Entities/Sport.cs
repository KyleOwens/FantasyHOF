using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class Sport
    {
        public SportId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected Sport() { }

        public Sport(SportId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
