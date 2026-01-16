using System.ComponentModel.DataAnnotations;

namespace FantasyHOF.Domain.Enums
{
    public enum PositionId
    {
        [Display(Name = "Quarterback")]
        QB = 0,
        [Display(Name = "Team quarterback")]
        TQB = 1,
        [Display(Name = "Running back")]
        RB = 2,
        [Display(Name = "Running back or wide receiver")]
        RBWR = 3,
        [Display(Name = "Wide receiver")]
        WR = 4,
        [Display(Name = "Wide receiver or tight end")]
        WRTE = 5,
        [Display(Name = "Tight end")]
        TE = 6,
        [Display(Name = "Offensive player")]
        OP = 7,
        [Display(Name = "Defensive tackle")]
        DT = 8,
        [Display(Name = "Defensive end")]
        DE = 9,
        [Display(Name = "Linebacker")]
        LB = 10,
        [Display(Name = "Defensive line")]
        DL = 11,
        [Display(Name = "Cornerback")]
        CB = 12,
        [Display(Name = "Safety")]
        S = 13,
        [Display(Name = "Defensive back")]
        DB = 14,
        [Display(Name = "Defensive player")]
        DP = 15,
        [Display(Name = "Defense & special teams")]
        DST = 16,
        [Display(Name = "Kicker")]
        K = 17,
        [Display(Name = "Punter")]
        P = 18,
        [Display(Name = "Head coach")]
        HC = 19,
        [Display(Name = "Bench")]
        BE = 20,
        [Display(Name = "Injured reserve")]
        IR = 21,
        [Display(Name = "Flex")]
        RBWRTE = 23,
        [Display(Name = "")]
        ER = 24,
        [Display(Name = "Rookie")]
        Rookie = 25,
        [Display(Name = "Unknown")]
        Unknown = 999
    }
}
