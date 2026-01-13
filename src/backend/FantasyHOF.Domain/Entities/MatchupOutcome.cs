using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class MatchupOutcome
    {
        public MatchupOutcomeId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected MatchupOutcome() { }

        public MatchupOutcome(MatchupOutcomeId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
