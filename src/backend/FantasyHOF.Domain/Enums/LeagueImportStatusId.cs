using System.ComponentModel.DataAnnotations;

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
