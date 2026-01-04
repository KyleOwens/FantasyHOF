using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
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
