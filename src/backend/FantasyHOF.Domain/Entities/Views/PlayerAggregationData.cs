using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities.Views
{
    public class PlayerAggregationData
    {
        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }
        public int Year { get; private set; }
        public int Week { get; private set; }
        public decimal PointsScored { get; private set; }
        public int PlayerId { get; private set; }
        public PositionId PositionId { get; private set; }

        public FantasyMember Member { get; private set; } = null!;
        public Player Player { get; private set; } = null!;
    }
}
