using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class MatchupRosterSpot
    {
        public int Id { get; private set; }
        public int MatchupId { get; private set; }
        public int PlayerId { get; private set; }

        public required PositionId PositionId { get; set; }
        public required decimal PointsScored { get; set; }

        public Player Player { get; set; } = null!;
        public Position Position { get; set; } = null!;
        public List<AccumulatedStat> AccumulatedStats { get; set; } = null!;
    }
}
