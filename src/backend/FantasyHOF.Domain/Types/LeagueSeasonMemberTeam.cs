using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonMemberTeam
    {
        public int LeagueSeasonId { get; private set; }
        public int MemberId { get; private set; }
        public int TeamId { get; private set; }

        public Team Team { get; private set; } = null!;
    }
}
