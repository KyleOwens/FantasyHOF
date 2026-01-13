using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Enums
{
    public enum LeagueImportStatusId
    {
        [Display(Name = "Queued")]
        Queued,
        [Display(Name = "Loading data from provider")]
        LoadingData,
        [Display(Name = "Formatting data")]
        FormattingData,
        [Display(Name = "Saving data")]
        SavingData,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Failed")]
        Failed = 999
    }
}
