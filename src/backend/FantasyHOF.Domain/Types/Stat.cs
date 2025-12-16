using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Types
{

    public class Stat
    {
        public StatId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected Stat() { }

        public Stat(StatId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}