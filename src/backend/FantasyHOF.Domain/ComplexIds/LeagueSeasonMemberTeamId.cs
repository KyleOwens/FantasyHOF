using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.ComplexIds
{
    public readonly record struct LeagueSeasonMemberTeamId(int LeagueSeasonId, int MemberId, int TeamId)
    {
        public override string ToString() => $"{LeagueSeasonId}:{MemberId}:{TeamId}";
        
        public static LeagueSeasonMemberTeamId Parse(string value)
        {
            string[] parts = value.Split(':');
            return new LeagueSeasonMemberTeamId(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
        }
    }
}
