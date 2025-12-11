using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyleagueSeason
    {
        public required int Year { get; set; }
        public required FantasyLeagueSettings Settings { get; init; }
        public required List<FantasyMember> Members { get; init; }
    }
}
