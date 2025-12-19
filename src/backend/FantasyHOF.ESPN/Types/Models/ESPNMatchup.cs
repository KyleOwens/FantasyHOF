using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNMatchup
    {
        public required int Id { get; set; }
        public ESPNMatchupTeam? Away { get; set; }
        public ESPNMatchupTeam? Home { get; set; }
        public required int MatchupPeriodId { get; set; }   
        public required string PlayoffTierType { get; set; }
        public required string Winner { get; set; }
    }
}
