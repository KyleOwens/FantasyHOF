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
        public required LeagueSeasonSettings Settings { get; init; }
        public required List<LeagueSeasonMember> Members { get; init; }
        public required List<FantasyMatchup> Matchups { get; init; }
    }
}
