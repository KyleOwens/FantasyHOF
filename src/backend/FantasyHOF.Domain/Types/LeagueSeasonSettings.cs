using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueSeasonSettings
    {
        public int Id { get; set; }
        public int LeagueSeasonId { get; set; }
        
        public required string LeagueName { get; set; }
        public required LeagueSeasonScheduleSettings ScheduleSettings { get; set; }
        public required LeagueSeasonScoringSettings ScoringSettings { get; set; }
    }
}
