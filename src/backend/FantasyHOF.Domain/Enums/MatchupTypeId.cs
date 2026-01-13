using System.ComponentModel.DataAnnotations;

namespace FantasyHOF.Domain.Enums
{
    public enum MatchupTypeId
    {
        [Display(Name = "Regular season")]
        RegularSeason,
        [Display(Name = "Losers bracket")]
        LosersBracket,
        [Display(Name = "Winners consolation")]
        WinnersConsolation,
        [Display(Name = "Winners bracket")]
        WinnersBracket,
        Unknown = 999
    }
}
