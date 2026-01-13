using FantasyHOF.Domain.ComplexIds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueSeasonMember
    {
        public int LeagueSeasonId { get; private set; }
        public int MemberId { get; private set; }

        public required bool IsLeagueCreator { get; init; }
        public required bool IsLeagueManager { get; init; }

        public FantasyMember Member { get; private set; } = null!;
        public List<LeagueSeasonMemberTeam> Teams { get; private set; } = null!;

        public LeagueSeasonMemberId Id => new(LeagueSeasonId, MemberId);

        public void SetMember(FantasyMember member)
        {
            Member = member;
        }

        public void SetTeams(List<LeagueSeasonMemberTeam> teams)
        {
            Teams = teams;
        }
    }
}
