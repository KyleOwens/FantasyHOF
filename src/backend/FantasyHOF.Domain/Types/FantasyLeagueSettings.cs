using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyLeagueSettings
    {
        public required string Name { get; set; }
        public required FantasyLeagueScheduleSettings ScheduleSettings { get; set; }
        public required FantasyLeagueScoringSettings ScoringSettings { get; set; }
    }
}
