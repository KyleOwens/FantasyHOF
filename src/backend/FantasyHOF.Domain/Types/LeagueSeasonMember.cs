using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonMember
    {
        public int LeagueSeasonId { get; private set; }
        public int MemberId { get; private set; }

        public required bool IsLeagueCreator { get; init; }
        public required bool IsLeagueManager { get; init; }
        public required List<LeagueSeasonMemberTeam> LeagueSeasonMemberTeams { get; init; }

        public FantasyMember Member { get; private set; } = null!;
    }
}
