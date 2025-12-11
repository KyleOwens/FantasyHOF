using FantasyHOF.ESPN.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Outputs
{
    public class ESPNWeeklyLeagueData
    {
        public required int Year { get; set; }
        public required int Week { get; set; }
        public required List<ESPNMatchup> Matchups { get; set; }
    }
}
