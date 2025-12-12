using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonMember
    {
        public int LeagueId { get; private set; }
        public int LeagueSeasonId { get; private set; }
        public int MemberId { get; private set; }

        public FantasyMember Member { get; private set; } = null!;
    }
}
