using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyAccumulatedStat
    {
        public required FantasyStat Stat { get; init; }
        public required float StatValue { get; init; }
        public required float PointsScored { get; init; }
    }
}
