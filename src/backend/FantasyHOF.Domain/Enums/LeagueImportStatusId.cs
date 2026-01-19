using System.ComponentModel.DataAnnotations;

namespace FantasyHOF.Domain.Enums
{
    public enum LeagueImportStatusId
    {
        [Display(Name = "Queued")]
        Queued,
        [Display(Name = "Loading seasonal data from provider")]
        LoadingSeasonalData,
        [Display(Name = "Loading weekly data from provider")]
        LoadingWeeklylData,
        [Display(Name = "Formatting data for save")]
        FormattingData,
        [Display(Name = "Saving data")]
        SavingData,
        [Display(Name = "Saving miscellaenous data")]
        SavingMiscellaneousData,
        [Display(Name = "Saving members")]
        SavingMembers,
        [Display(Name = "Saving seasons")]
        SavingSeasons,
        [Display(Name = "Saving teams")]
        SavingTeams,
        [Display(Name = "Saving matchups")]
        SavingMatchups,
        [Display(Name = "Saving rosters")]
        SavingRosters,
        [Display(Name = "Saving stats")]
        SavingStats,
        [Display(Name = "Completed")]
        Completed,
        [Display(Name = "Failed")]
        Failed = 999
    }
}
