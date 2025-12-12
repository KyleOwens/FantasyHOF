using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueSeason
    {
        public int Id { get; private set; }
        public int LeagueId { get; private set; }

        public required int Year { get; init; }
        public LeagueSeasonSettings Settings { get; set; } = null!;
        //public List<LeagueSeasonMember> LeagueSeasonMembers { get; set; } = null!;
        //public required List<TeamMatchup> Matchups { get; init; }
    }
}
