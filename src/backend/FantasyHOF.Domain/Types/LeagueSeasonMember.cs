using FantasyHOF.Domain.ComplexIds;
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

        public FantasyMember Member { get; set; } = null!;
        public List<LeagueSeasonMemberTeam> LeagueSeasonMemberTeams { get; set; } = null!;

        public LeagueSeasonMemberId Id => new(LeagueSeasonId, MemberId);
    }
}
