using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public enum FantasyPositionId
    {
        QB = 0,
        TQB = 1,
        RB = 2,
        RBWR = 3,
        WR = 4,
        WRTE = 5,
        TE = 6,
        OP = 7,
        DT = 8,
        DE = 9,
        LB = 10,
        DL = 11,
        CB = 12,
        S = 13,
        DB = 14,
        DP = 15,
        DST = 16,
        K = 17,
        P = 18,
        HC = 19,
        BE = 20,
        IR = 21,
        // 22 intentionally skipped
        RBWRTE = 23,
        ER = 24,
        Rookie = 25
    }

    public class FantasyRosterSpot
    {
        public required FantasyPositionId LineupSlotId { get; set; }
        public required int PlayerId { get; set; }
        public required FantasyPlayer Player { get; set; }
        public required float PointsScored { get; set; }
        public required List<FantasyAccumulatedStat> Stats { get; set; }
    }
}
