using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
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
