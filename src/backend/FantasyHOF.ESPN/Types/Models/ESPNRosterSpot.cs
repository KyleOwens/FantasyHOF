namespace FantasyHOF.ESPN.Types.Models
{
    public enum ESPNLineupSlotId
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
        RBWRTE = 23,
        ER = 24,
        Rookie = 25
    }

    public class ESPNRosterSpot
    {
        public required ESPNLineupSlotId LineupSlotId { get; set; }
        public required ESPNPlayerEntry PlayerPoolEntry { get; set; }
    }
}