using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
