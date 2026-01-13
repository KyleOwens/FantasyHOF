using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class MatchupType
    {
        public MatchupTypeId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected MatchupType() { }

        public MatchupType(MatchupTypeId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
