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

        public Player Player { get; private set; } = null!;
        public Position Position { get; private set; } = null!;
        public List<AccumulatedStat> AccumulatedStats { get; private set; } = null!;

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public void SetPosition(Position position)
        {
            Position = position;
        }
        
        public void SetAccumulatedStats(List<AccumulatedStat> accumulatedStats)
        {
            AccumulatedStats = accumulatedStats;
        }
    }
}
