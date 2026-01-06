using FantasyHOF.Domain.Types.Records;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Enums
{
   public enum RecordType
    {
        // ==================== Fame LEAGUE ====================
        [RecordMetadata("Most championships", "championships", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostChampionships.webp")]
        MostChampionshipsLeagueHistory,

        [RecordMetadata("Highest championship percentage", "of seasons", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestChampPercentage.webp", true)]
        HighestChampionshipPercentageLeagueHistory,

        [RecordMetadata("Most wins", "wins", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostWins.webp")]
        MostWinsLeagueHistory,

        [RecordMetadata("Highest win percentage", "of weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestWinPercentage.webp", true)]
        HighestWinPercentageLeagueHistory,

        [RecordMetadata("Most winning seasons", "seasons", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostWinningSeasons.webp")]
        MostSeasonsWinningRecordLeagueHistory,

        [RecordMetadata("Highest winning season percentage", "of seasons", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestWinningSeasonPercentage.webp", true)]
        HighestWinningRecordPercentageLeagueHistory,

        [RecordMetadata("Most points", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostPoints.webp")]
        MostPointsLeagueHistory,

        [RecordMetadata("Most points per week", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostPointsPerWeek.webp")]
        MostAveragePointsPerWeekLeagueHistory,

        [RecordMetadata("Most outstanding performances", "monster weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostOutstanding.webp")]
        MostOutstandingPerformancesLeagueHistory,

        [RecordMetadata("Most blowout wins", "blowouts", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostBlowoutWins.webp")]
        MostBlowoutWinsLeagueHistory,

        [RecordMetadata("Most narrow wins", "heart attacks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostNarrowWins.webp")]
        MostNarrowWinsLeagueHistory,

        [RecordMetadata("Most top weekly scores", "weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostTopWeeks.webp")]
        MostTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest top weekly score percentage", "of weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestTopWeekPercentage.webp", true)]
        HighestPercentageTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Least losses", "losses", RecordCategory.League, RecordSentiment.Fame, "/record-icons/LeastLosses.webp")]
        LeastLossesLeagueHistory,

        [RecordMetadata("Least points allowed", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/LeastPointsAllowed.webp")]
        LeastPointsAllowedLeagueHistory,

        [RecordMetadata("Least points allowed per week", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/LeastPointsAllowedPerWeek.webp")]
        LeastAveragePointsAllowedPerWeekLeagueHistory,

        // ==================== Shame LEAGUE ====================
        [RecordMetadata("Most last places", "last places", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostLastPlaces.webp")]
        MostLastPlacesLeagueHistory,

        [RecordMetadata("Highest last place percentage", "of seasons", RecordCategory.League, RecordSentiment.Shame, "/record-icons/HighestLastPlacePercentage.webp", true)]
        HighestLastPlacePercentageLeagueHistory,

        [RecordMetadata("Most losses", "losses", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostLosses.webp")]
        MostLossesLeagueHistory,

        [RecordMetadata("Lowest win percentage", "of weeks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LowestWinPercentage.webp", true)]
        LowestWinPercentageLeagueHistory,

        [RecordMetadata("Most losing seasons", "seasons", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostLosingSeasons.webp")]
        MostSeasonsLosingRecordLeagueHistory,

        [RecordMetadata("Highest losing season percentage", "of seasons", RecordCategory.League, RecordSentiment.Shame, "/record-icons/HighestLosingSeasonPercentage.webp", true)]
        HighestLosingRecordPercentageLeagueHistory,

        [RecordMetadata("Most points allowed", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostPointsAllowed.webp")]
        MostPointsAllowedLeagueHistory,

        [RecordMetadata("Most points allowed per week", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostPointsAllowedPerWeek.webp")]
        MostAveragePointsAllowedPerWeekLeagueHistory,

        [RecordMetadata("Most poor performances", "snoozers", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostPoor.webp")]
        MostPoorPerformancesLeagueHistory,

        [RecordMetadata("Most blowout losses", "beatdowns", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostBlowoutLosses.webp")]
        MostBlowoutLossesLeagueHistory,

        [RecordMetadata("Most narrow losses", "heart breaks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostNarrowLosses.webp")]
        MostNarrowLossesLeagueHistory,

        [RecordMetadata("Most bottom weekly scores", "weeks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostBottomWeeks.webp")]
        MostLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest bottom weekly score percentage", "of weeks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/HighestBottomWeekPercentage.webp", true)]
        HighestPercentageLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Least wins", "wins", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LeastWins.webp")]
        LeastWinsLeagueHistory,

        [RecordMetadata("Least points", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LeastPoints.webp")]
        LeastPointsLeagueHistory,

        [RecordMetadata("Least points per week", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LeastPointsPerWeek.webp")]
        LeastAveragePointsPerWeekLeagueHistory,

        // ==================== Fame SEASONAL ====================
        [RecordMetadata("Most points", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostPoints.webp")]
        MostPointsSingleSeason,

        [RecordMetadata("Most points per week", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostPointsPerWeek.webp")]
        MostPointsPerWeekSingleSeason,

        [RecordMetadata("Least points allowed", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/LeastPointsAllowed.webp")]
        LeastPointsAllowedSingleSeason,

        [RecordMetadata("Least points allowed per week", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/LeastPointsAllowedPerWeek.webp")]
        LeastPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most wins", "wins", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostWins.webp")]
        MostWinsSingleSeason,

        [RecordMetadata("Most outstanding performances", "monster weeks", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostOutstanding.webp")]
        MostOutstandingPerformancesSingleSeason,

        [RecordMetadata("Most blowout wins", "blowouts", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostBlowoutWins.webp")]
        MostBlowoutWinsSingleSeason,

        [RecordMetadata("Most narrow wins", "heart attacks", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostNarrowWins.webp")]
        MostNarrowWinsSingleSeason,

        [RecordMetadata("Most top scoring weeks", "weeks", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostTopWeeks.webp")]
        MostHighestScoringWeeksSingleSeason,

        // ==================== Shame SEASONAL ====================
        [RecordMetadata("Least points", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/LeastPoints.webp")]
        LeastPointsSingleSeason,

        [RecordMetadata("Least points per week", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/LeastPointsPerWeek.webp")]
        LeastPointsPerWeekSingleSeason,

        [RecordMetadata("Most points allowed", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostPointsAllowed.webp")]
        MostPointsAllowedSingleSeason,

        [RecordMetadata("Most points allowed per week", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostPointsAllowedPerWeek.webp")]
        MostPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most losses", "losses", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostLosses.webp")]
        MostLossesSingleSeason,

        [RecordMetadata("Most poor performances", "snoozers", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostPoor.webp")]
        MostPoorPerformancesSingleSeason,

        [RecordMetadata("Most blowout losses", "beatdowns", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostBlowoutLosses.webp")]
        MostBlowoutLossesSingleSeason,

        [RecordMetadata("Most narrow losses", "heartbreaks", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostNarrowLosses.webp")]
        MostNarrowLossesSingleSeason,

        [RecordMetadata("Most bottom scoring weeks", "weeks", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostBottomWeeks.webp")]
        MostLowestScoringWeeksSingleSeason,

        // ==================== Fame WEEKLY ====================
        [RecordMetadata("Most points", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/MostPoints.webp")]
        MostPointsSingleWeek,

        [RecordMetadata("Most points (playoffs)", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/MostPointsPlayoffWeek.webp")]
        MostPointsSinglePlayoffWeek,

        [RecordMetadata("Largest margin of victory", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/LargestMargin.webp")]
        LargestMarginOfVictorySingleWeek,

        [RecordMetadata("Largest margin of victory (playoffs)", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/LargestMarginPlayoffWeek.webp")]
        LargestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Lowest scoring win", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/LowestScoringWin.webp")]
        LowestScoringWinSingleWeek,

        // ==================== Shame WEEKLY ====================
        [RecordMetadata("Least points", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/LeastPoints.webp")]
        LeastPointsSingleWeek,

        [RecordMetadata("Least points (playoffs)", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/LeastPointsPlayoff.webp")]
        LeastPointsSinglePlayoffWeek,

        [RecordMetadata("Smallest margin of victory", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/SmallestMargin.webp")]
        LowestMarginOfVictorySingleWeek,

        [RecordMetadata("Smallest margin of victory (playoffs)", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/SmallestMarginPlayoff.webp")]
        LowestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Highest scoring loss", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/HighestScoringLoss.webp")]
        HighestScoringLossSingleWeek,

        // ==================== Fame PLAYER ====================
        [RecordMetadata("Most points", "points", RecordCategory.Player, RecordSentiment.Fame, "/record-icons/MostPointsPlayer.webp")]
        MostPointsScoredSinglePlayer,

        [RecordMetadata("Most points (non-QB)", "points", RecordCategory.Player, RecordSentiment.Fame, "/record-icons/MostPointsNonQBPlayer.webp")]
        MostPointsScoredSingleNonQBPlayer,

        // ==================== Shame PLAYER ====================
        [RecordMetadata("Least points", "points", RecordCategory.Player, RecordSentiment.Shame, "/record-icons/LeastPointsPlayer.webp")]
        LeastPointsScoredSinglePlayer,

        [RecordMetadata("Least Points (non-DST)", "points", RecordCategory.Player, RecordSentiment.Shame, "/record-icons/LeastPointsNonDefPlayer.webp")]
        LeastPointsScoredSingleNonDefensePlayer,
    }

    public enum RecordCategory
    {
        [Display(Name = "League")]
        League,
        [Display(Name = "Season")]
        Season,
        [Display(Name = "Week")]
        Week,
        [Display(Name = "Player")]
        Player
    }

    public enum RecordSentiment
    {
        Fame,
        Shame
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RecordMetadataAttribute : Attribute
    {
        public string DisplayName { get; }
        public string Metric { get; }
        public RecordCategory Category { get; }
        public RecordSentiment Sentiment { get; }
        public string IconURI { get; }
        public bool IsPercentage { get; }

        public RecordMetadataAttribute(
            string displayName,
            string metric,
            RecordCategory category,
            RecordSentiment sentiment,
            string iconURI,
            bool isPercentage = false)
        {
            DisplayName = displayName;
            Category = category;
            Sentiment = sentiment;
            Metric = metric;
            IconURI = iconURI;
            IsPercentage = isPercentage;
        }
    }

    public static class RecordTypeExtensions
    {
        private static readonly Dictionary<RecordType, RecordMetadataAttribute> MetadataCache =
            Enum.GetValues<RecordType>()
                .ToDictionary(
                    t => t,
                    t => typeof(RecordType)
                        .GetField(t.ToString())!
                        .GetCustomAttribute<RecordMetadataAttribute>()!);

        public static RecordMetadataAttribute GetMetadata(this RecordType recordType) =>
            MetadataCache[recordType];
    }

    
}
