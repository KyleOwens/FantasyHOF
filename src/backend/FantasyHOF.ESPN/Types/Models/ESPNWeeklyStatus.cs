using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNWeeklyStatus
    {
        public required int FirstScoringPeriod { get; set; }
        public required int FinalScoringPeriod { get; set; }
        public required int CurrentMatchupPeriod { get; set; }
    }
}
