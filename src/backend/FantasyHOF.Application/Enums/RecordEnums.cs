using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Enums
{
   public enum RecordTypeId
    {
        // ==================== Fame LEAGUE ====================
        [RecordMetadata("Most championships", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.Championships, RecordMetricType.Scalar,
            "/record-icons/MostChampionships.webp")]
        MostChampionshipsLeagueHistory,

        [RecordMetadata("Highest championship percentage", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.ChampionshipPercentage, RecordMetricType.Ratio,   
            "/record-icons/HighestChampPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.Championships, RecordMetricId.Seasons)]
        HighestChampionshipPercentageLeagueHistory,

        [RecordMetadata("Most wins", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.Wins, RecordMetricType.Scalar, 
            "/record-icons/MostWins.webp")]
        MostWinsLeagueHistory,

        [RecordMetadata("Highest win percentage", RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.WinPercentage, RecordMetricType.Ratio,  
            "/record-icons/HighestWinPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.Wins, RecordMetricId.Weeks)]
        HighestWinPercentageLeagueHistory,

        [RecordMetadata("Most winning seasons", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.WinningSeasons, RecordMetricType.Scalar,   
            "/record-icons/MostWinningSeasons.webp")]
        MostSeasonsWinningRecordLeagueHistory,

        [RecordMetadata("Highest winning season percentage", RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.WinningSeasonPercentage, RecordMetricType.Ratio,  
            "/record-icons/HighestWinningSeasonPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.WinningSeasons, RecordMetricId.Seasons)]
        HighestWinningRecordPercentageLeagueHistory,

        [RecordMetadata("Most points", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.PointsFor, RecordMetricType.Scalar,  
            "/record-icons/MostPoints.webp")]
        MostPointsLeagueHistory,

        [RecordMetadata("Most points per week", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar, 
            "/record-icons/MostPointsPerWeek.webp")]
        MostAveragePointsPerWeekLeagueHistory,

        [RecordMetadata("Most outstanding performances", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.OutstandingPerformances, RecordMetricType.Scalar,  
            "/record-icons/MostOutstanding.webp")]
        MostOutstandingPerformancesLeagueHistory,

        [RecordMetadata("Most blowout wins", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.BlowoutWins, RecordMetricType.Scalar,  
            "/record-icons/MostBlowoutWins.webp")]
        MostBlowoutWinsLeagueHistory,

        [RecordMetadata("Most narrow wins", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.NarrowWins, RecordMetricType.Scalar,   
            "/record-icons/MostNarrowWins.webp")]
        MostNarrowWinsLeagueHistory,

        [RecordMetadata("Most top weekly scores", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.TopWeeks, RecordMetricType.Scalar,   
            "/record-icons/MostTopWeeks.webp")]
        MostTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest top weekly score percentage", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.TopWeekPercentage, RecordMetricType.Ratio,   
            "/record-icons/HighestTopWeekPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.TopWeeks, RecordMetricId.Weeks)]
        HighestPercentageTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Least losses", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.Losses, RecordMetricType.Scalar,  
            "/record-icons/LeastLosses.webp",
            SortDirection.Ascending)]
        LeastLossesLeagueHistory,

        [RecordMetadata("Least points allowed", RecordCategoryId.League, RecordSentiment.Fame, 
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar, 
            "/record-icons/LeastPointsAllowed.webp",
            SortDirection.Ascending)]
        LeastPointsAllowedLeagueHistory,

        [RecordMetadata("Least points allowed per week", RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Ratio,
            "/record-icons/LeastPointsAllowedPerWeek.webp",
            SortDirection.Ascending)]
        [RatioRecordMetadata(RecordMetricId.PointsFor, RecordMetricId.Weeks)]
        LeastAveragePointsAllowedPerWeekLeagueHistory,

        // ==================== Shame LEAGUE ====================
        [RecordMetadata("Most last places", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.LastPlaces, RecordMetricType.Scalar,  
            "/record-icons/MostLastPlaces.webp")]
        MostLastPlacesLeagueHistory,

        [RecordMetadata("Highest last place percentage", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.LastPlacePercentage, RecordMetricType.Ratio,  
            "/record-icons/HighestLastPlacePercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.LastPlaces, RecordMetricId.Seasons)]
        HighestLastPlacePercentageLeagueHistory,

        [RecordMetadata("Most losses", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.Losses, RecordMetricType.Scalar,   
            "/record-icons/MostLosses.webp")]
        MostLossesLeagueHistory,

        [RecordMetadata("Lowest win percentage", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.WinPercentage, RecordMetricType.Ratio, 
            "/record-icons/LowestWinPercentage.webp", 
            SortDirection.Ascending)]
        [RatioRecordMetadata(RecordMetricId.Wins, RecordMetricId.Weeks)]
        LowestWinPercentageLeagueHistory,

        [RecordMetadata("Most losing seasons", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.LosingSeasons, RecordMetricType.Scalar,  
            "/record-icons/MostLosingSeasons.webp")]
        MostSeasonsLosingRecordLeagueHistory,

        [RecordMetadata("Highest losing season percentage", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.LosingSeasonPercentage, RecordMetricType.Ratio, 
            "/record-icons/HighestLosingSeasonPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.LosingSeasons, RecordMetricId.Seasons)]
        HighestLosingRecordPercentageLeagueHistory,

        [RecordMetadata("Most points allowed", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar, 
            "/record-icons/MostPointsAllowed.webp")]
        MostPointsAllowedLeagueHistory,

        [RecordMetadata("Most points allowed per week", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Scalar,
            "/record-icons/MostPointsAllowedPerWeek.webp")]
        MostAveragePointsAllowedPerWeekLeagueHistory,

        [RecordMetadata("Most poor performances", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.PoorPerformances, RecordMetricType.Scalar,   
            "/record-icons/MostPoor.webp")]
        MostPoorPerformancesLeagueHistory,

        [RecordMetadata("Most blowout losses", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.BlowoutLosses, RecordMetricType.Scalar,   
            "/record-icons/MostBlowoutLosses.webp")]
        MostBlowoutLossesLeagueHistory,

        [RecordMetadata("Most narrow losses", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.NarrowLosses, RecordMetricType.Scalar, 
            "/record-icons/MostNarrowLosses.webp")]
        MostNarrowLossesLeagueHistory,

        [RecordMetadata("Most bottom weekly scores", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.BottomWeeks, RecordMetricType.Scalar,  
            "/record-icons/MostBottomWeeks.webp")]
        MostLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest bottom weekly score percentage", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.BottomWeekPercentage, RecordMetricType.Ratio, 
            "/record-icons/HighestBottomWeekPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.BottomWeeks, RecordMetricId.Weeks)]
        HighestPercentageLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Least wins", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.Wins, RecordMetricType.Scalar, 
            "/record-icons/LeastWins.webp", 
            SortDirection.Ascending)]
        LeastWinsLeagueHistory,

        [RecordMetadata("Least points", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.PointsFor, RecordMetricType.Scalar, 
            "/record-icons/LeastPoints.webp", 
            SortDirection.Ascending)]
        LeastPointsLeagueHistory,

        [RecordMetadata("Least points per week", RecordCategoryId.League, RecordSentiment.Shame, 
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar,  
            "/record-icons/LeastPointsPerWeek.webp",
            SortDirection.Ascending)]
        LeastAveragePointsPerWeekLeagueHistory,

        // ==================== Fame SEASONAL ====================
        [RecordMetadata("Most points", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.PointsFor, RecordMetricType.Scalar, 
            "/record-icons/MostPoints.webp")]
        MostPointsSingleSeason,

        [RecordMetadata("Most points per week", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar, 
            "/record-icons/MostPointsPerWeek.webp")]
        MostPointsPerWeekSingleSeason,

        [RecordMetadata("Least points allowed", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar,  
            "/record-icons/LeastPointsAllowed.webp",
            SortDirection.Ascending)]
        LeastPointsAllowedSingleSeason,

        [RecordMetadata("Least points allowed per week", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Scalar, 
            "/record-icons/LeastPointsAllowedPerWeek.webp",
            SortDirection.Ascending)]
        LeastPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most wins", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.Wins, RecordMetricType.Scalar,   
            "/record-icons/MostWins.webp")]
        MostWinsSingleSeason,

        [RecordMetadata("Most outstanding performances", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.OutstandingPerformances, RecordMetricType.Scalar, 
            "/record-icons/MostOutstanding.webp")]
        MostOutstandingPerformancesSingleSeason,

        [RecordMetadata("Most blowout wins", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.BlowoutWins, RecordMetricType.Scalar, 
            "/record-icons/MostBlowoutWins.webp")]
        MostBlowoutWinsSingleSeason,

        [RecordMetadata("Most narrow wins", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.NarrowWins, RecordMetricType.Scalar,  
            "/record-icons/MostNarrowWins.webp")]
        MostNarrowWinsSingleSeason,

        [RecordMetadata("Most top scoring weeks", RecordCategoryId.Season, RecordSentiment.Fame, 
            RecordMetricId.TopWeeks, RecordMetricType.Scalar,   
            "/record-icons/MostTopWeeks.webp")]
        MostHighestScoringWeeksSingleSeason,

        // ==================== Shame SEASONAL ====================
        [RecordMetadata("Least points", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.PointsFor, RecordMetricType.Scalar,  
            "/record-icons/LeastPoints.webp",
            SortDirection.Ascending)]
        LeastPointsSingleSeason,

        [RecordMetadata("Least points per week", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar,  
            "/record-icons/LeastPointsPerWeek.webp",
            SortDirection.Ascending)]
        LeastPointsPerWeekSingleSeason,

        [RecordMetadata("Most points allowed", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar,  
            "/record-icons/MostPointsAllowed.webp")]
        MostPointsAllowedSingleSeason,

        [RecordMetadata("Most points allowed per week", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Scalar, 
            "/record-icons/MostPointsAllowedPerWeek.webp")]
        MostPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most losses", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.Losses, RecordMetricType.Scalar,  
            "/record-icons/MostLosses.webp")]
        MostLossesSingleSeason,

        [RecordMetadata("Most poor performances", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.PoorPerformances, RecordMetricType.Scalar,  
            "/record-icons/MostPoor.webp")]
        MostPoorPerformancesSingleSeason,

        [RecordMetadata("Most blowout losses", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.BlowoutLosses, RecordMetricType.Scalar, 
            "/record-icons/MostBlowoutLosses.webp")]
        MostBlowoutLossesSingleSeason,

        [RecordMetadata("Most narrow losses", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.NarrowLosses, RecordMetricType.Scalar,
            "/record-icons/MostNarrowLosses.webp")]
        MostNarrowLossesSingleSeason,

        [RecordMetadata("Most bottom scoring weeks", RecordCategoryId.Season, RecordSentiment.Shame, 
            RecordMetricId.BottomWeeks, RecordMetricType.Scalar, 
            "/record-icons/MostBottomWeeks.webp")]
        MostLowestScoringWeeksSingleSeason,

        // ==================== Fame WEEKLY ====================
        [RecordMetadata("Most points", RecordCategoryId.Week, RecordSentiment.Fame, 
            RecordMetricId.Score, RecordMetricType.Scalar, 
            "/record-icons/MostPoints.webp")]
        MostPointsSingleWeek,

        [RecordMetadata("Most points (playoffs)", RecordCategoryId.Week, RecordSentiment.Fame, 
            RecordMetricId.PlayoffScore, RecordMetricType.Scalar, 
            "/record-icons/MostPointsPlayoffWeek.webp")]
        MostPointsSinglePlayoffWeek,

        [RecordMetadata("Largest margin of victory", RecordCategoryId.Week, RecordSentiment.Fame, 
            RecordMetricId.VictoryScoreMargin, RecordMetricType.Scalar,
            "/record-icons/LargestMargin.webp")]
        LargestMarginOfVictorySingleWeek,

        [RecordMetadata("Largest margin of victory (playoffs)", RecordCategoryId.Week, RecordSentiment.Fame, 
            RecordMetricId.PlayoffVictoryScoreMargin, RecordMetricType.Scalar, 
            "/record-icons/LargestMarginPlayoffWeek.webp")]
        LargestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Lowest scoring win", RecordCategoryId.Week, RecordSentiment.Fame, 
            RecordMetricId.WinScore, RecordMetricType.Scalar,
            "/record-icons/LowestScoringWin.webp",
            SortDirection.Ascending)]
        LowestScoringWinSingleWeek,

        // ==================== Shame WEEKLY ====================
        [RecordMetadata("Least points", RecordCategoryId.Week, RecordSentiment.Shame, 
            RecordMetricId.Score, RecordMetricType.Scalar, 
            "/record-icons/LeastPoints.webp",
            SortDirection.Ascending)]
        LeastPointsSingleWeek,

        [RecordMetadata("Least points (playoffs)", RecordCategoryId.Week, RecordSentiment.Shame, 
            RecordMetricId.PlayoffScore, RecordMetricType.Scalar, 
            "/record-icons/LeastPointsPlayoff.webp",
            SortDirection.Ascending)]
        LeastPointsSinglePlayoffWeek,

        [RecordMetadata("Smallest margin of victory", RecordCategoryId.Week, RecordSentiment.Shame, 
            RecordMetricId.VictoryScoreMargin, RecordMetricType.Scalar,
            "/record-icons/SmallestMargin.webp",
            SortDirection.Ascending)]
        LowestMarginOfVictorySingleWeek,

        [RecordMetadata("Smallest margin of victory (playoffs)", RecordCategoryId.Week, RecordSentiment.Shame, 
            RecordMetricId.PlayoffVictoryScoreMargin, RecordMetricType.Scalar, 
            "/record-icons/SmallestMarginPlayoff.webp",
            SortDirection.Ascending)]
        LowestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Highest scoring loss", RecordCategoryId.Week, RecordSentiment.Shame, 
            RecordMetricId.LossScore, RecordMetricType.Scalar,  
            "/record-icons/HighestScoringLoss.webp")]
        HighestScoringLossSingleWeek,

        // ==================== Fame PLAYER ====================
        [RecordMetadata("Most points", RecordCategoryId.Player, RecordSentiment.Fame, 
            RecordMetricId.PointsScored, RecordMetricType.Scalar, 
            "/record-icons/MostPointsPlayer.webp")]
        MostPointsScoredSinglePlayer,

        [RecordMetadata("Most points (non-QB)", RecordCategoryId.Player, RecordSentiment.Fame, 
            RecordMetricId.PointsScoredNonQB, RecordMetricType.Scalar, 
            "/record-icons/MostPointsNonQBPlayer.webp")]
        MostPointsScoredSingleNonQBPlayer,

        // ==================== Shame PLAYER ====================
        [RecordMetadata("Least points", RecordCategoryId.Player, RecordSentiment.Shame, 
            RecordMetricId.PointsScored, RecordMetricType.Scalar, 
            "/record-icons/LeastPointsPlayer.webp", 
            SortDirection.Ascending)]
        LeastPointsScoredSinglePlayer,

        [RecordMetadata("Least Points (non-DST)", RecordCategoryId.Player, RecordSentiment.Shame, 
            RecordMetricId.PointsScoredNonDST, RecordMetricType.Scalar, 
            "/record-icons/LeastPointsNonDefPlayer.webp",
            SortDirection.Ascending)]
        LeastPointsScoredSingleNonDefensePlayer,
    }

    public enum RecordCategoryId
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

    public enum RecordMetricId
    {
        [Display(Name = "points")]
        PointsFor,
        [Display(Name = "points")]
        PointsForAverage,
        [Display(Name = "points")]
        PointsAgainst,
        [Display(Name = "points")]
        PointsAgainstAverage,
        [Display(Name = "wins")]
        Wins,
        [Display(Name = "losses")]
        Losses,
        [Display(Name = "of weeks")]
        WinPercentage,
        [Display(Name = "weeks")]
        TopWeeks,
        [Display(Name = "of weeks")]
        TopWeekPercentage,
        [Display(Name = "weekss")]
        BottomWeeks,
        [Display(Name = "of weeks")]
        BottomWeekPercentage,
        [Display(Name = "blowouts")]
        BlowoutWins,
        [Display(Name = "blowouts")]
        BlowoutLosses,
        [Display(Name = "heart attacks")]
        NarrowWins,
        [Display(Name = "heart breakers")]
        NarrowLosses,
        [Display(Name = "championships")]
        Championships,
        [Display(Name = "of seasons")]
        ChampionshipPercentage,
        [Display(Name = "last places")]
        LastPlaces,
        [Display(Name = "of seasons")]
        LastPlacePercentage,
        [Display(Name = "seasons")]
        WinningSeasons,
        [Display(Name = "of seasons")]
        WinningSeasonPercentage,
        [Display(Name = "seasons")]
        LosingSeasons,
        [Display(Name = "of seasons")]
        LosingSeasonPercentage,
        [Display(Name = "monster weeks")]
        OutstandingPerformances,
        [Display(Name = "snoozers")]
        PoorPerformances,
        [Display(Name = "points")]
        Score,
        [Display(Name = "points")]
        PlayoffScore,
        [Display(Name = "points")]
        WinScore,
        [Display(Name = "points")]
        LossScore,
        [Display(Name = "points")]
        VictoryScoreMargin,
        [Display(Name = "points")]
        PlayoffVictoryScoreMargin,
        [Display(Name = "points")]
        WinMargin,
        [Display(Name = "points")]
        LossMargin,
        [Display(Name = "points")]
        PointsScored,
        [Display(Name = "points")]
        PointsScoredNonQB,
        [Display(Name = "points")]
        PointsScoredNonDST,
        [Display(Name = "seasons")]
        Seasons,
        [Display(Name = "points")]
        Weeks
    }

    public enum RecordSentiment
    {
        Fame,
        Shame
    }

    public enum RecordMetricType
    {
        Scalar,
        Ratio
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RecordMetadataAttribute : Attribute
    {
        public string DisplayName { get; }
        public RecordCategoryId Category { get; }
        public RecordSentiment Sentiment { get; }
        public RecordMetricId Metric { get; }
        public RecordMetricType MetricType { get; }
        public string IconURI { get; }
        public SortDirection SortDirection { get; }

        public RecordMetadataAttribute(
            string displayName,
            RecordCategoryId category,
            RecordSentiment sentiment,
            RecordMetricId metric,
            RecordMetricType metricType,
            string iconURI,
            SortDirection sortDirection = SortDirection.Descending)
        {
            DisplayName = displayName;
            Category = category;
            Sentiment = sentiment;
            Metric = metric;
            MetricType = metricType;
            IconURI = iconURI;
            SortDirection = sortDirection;
        }
    }

    [AttributeUsage(AttributeTargets.Field)]
    public class RatioRecordMetadataAttribute : Attribute
    {
        public RecordMetricId NumeratorMetric { get; }
        public RecordMetricId DenominatorMetric { get; }

        public RatioRecordMetadataAttribute(RecordMetricId numeratorMetric, RecordMetricId denominatorMetric)
        {
            NumeratorMetric = numeratorMetric;
            DenominatorMetric = denominatorMetric;
        }
    }

    public static class RecordTypeExtensions
    {
        private static readonly Dictionary<RecordTypeId, RecordMetadataAttribute> MetadataCache =
            Enum.GetValues<RecordTypeId>()
                .ToDictionary(
                    t => t,
                    t => typeof(RecordTypeId)
                        .GetField(t.ToString())!
                        .GetCustomAttribute<RecordMetadataAttribute>()!);

        private static readonly Dictionary<RecordTypeId, RatioRecordMetadataAttribute> RatioMetadataCache =
            Enum.GetValues<RecordTypeId>()
                .ToDictionary(
                    t => t,
                    t => typeof(RecordTypeId)
                        .GetField(t.ToString())!
                        .GetCustomAttribute<RatioRecordMetadataAttribute>()!);

        public static RecordMetadataAttribute GetMetadata(this RecordTypeId recordType) =>
            MetadataCache[recordType];

        public static RatioRecordMetadataAttribute GetRatioMetadta(this RecordTypeId recordType) =>
            RatioMetadataCache[recordType];
    }
}
