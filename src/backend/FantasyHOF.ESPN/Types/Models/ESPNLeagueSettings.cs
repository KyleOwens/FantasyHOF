using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNLeagueSettings
    {
        public string Name { get; set; } = default!;
        public int MatchupPeriodCount { get; set; }
        public ESPNScheduleSettings ScheduleSettings { get; set; } = default!;
        public ESPNScoringSettings ScoringSettings { get; set; } = default!;
    }
}
