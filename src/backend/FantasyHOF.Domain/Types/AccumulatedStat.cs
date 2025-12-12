using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class AccumulatedStat
    {
        public int Id { get; private set; }
        public int MatchupRosterSpotId { get; private set; }
        public StatId StatId { get; private set; }
        
        public required Stat Stat { get; init; }
        public required float StatValue { get; init; }
        public required float PointsScored { get; init; }
    }
}
