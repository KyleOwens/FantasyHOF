using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class Position
    {
        public PositionId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected Position() { }

        public Position(PositionId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
