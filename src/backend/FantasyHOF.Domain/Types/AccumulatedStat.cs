using FantasyHOF.Domain.Enums;
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
        
        public required StatId StatId { get; init; }
        public required decimal StatValue { get; init; }
        public required decimal PointsScored { get; init; }

        public Stat Stat { get; private set; } = null!;
    }
}
