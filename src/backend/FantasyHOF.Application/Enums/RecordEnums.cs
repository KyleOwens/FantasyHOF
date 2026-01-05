using FantasyHOF.Domain.Types.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Enums
{
   public enum RecordType
    {
        // ==================== Fame LEAGUE ====================
        [RecordMetadata("Most championships", "championships", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostChampionshipsLeague.webp")]
        MostChampionshipsLeagueHistory,

        [RecordMetadata("Highest championship percentage", "of seasons", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestChampPercentageLeague.webp", true)]
        HighestChampionshipPercentageLeagueHistory,

        [RecordMetadata("Most wins", "wins", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostWinsLeague.webp")]
        MostWinsLeagueHistory,

        [RecordMetadata("Highest win percentage", "of weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestWinPercentageLeague.webp", true)]
        HighestWinPercentageLeagueHistory,

        [RecordMetadata("Most winning seasons", "seasons", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostWinningSeasonsLeague.webp")]
        MostSeasonsWinningRecordLeagueHistory,

        [RecordMetadata("Highest winning season percentage", "of seasons", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestWinningSeasonPercentageLeague.webp", true)]
        HighestWinningRecordPercentageLeagueHistory,

        [RecordMetadata("Most points", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostPointsLeague.webp")]
        MostPointsLeagueHistory,

        [RecordMetadata("Most points per week", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostPointsPerWeekLeague.webp")]
        MostAveragePointsPerWeekLeagueHistory,

        [RecordMetadata("Most outstanding performances", "monster weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostOutstandingLeague.webp")]
        MostOutstandingPerformancesLeagueHistory,

        [RecordMetadata("Most blowout wins", "blowouts", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostBlowoutWinsLeague.webp")]
        MostBlowoutWinsLeagueHistory,

        [RecordMetadata("Most narrow wins", "heart attacks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostNarrowWinsLeague.webp")]
        MostNarrowWinsLeagueHistory,

        [RecordMetadata("Most top weekly scores", "weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/MostTopWeeksLeague.webp")]
        MostTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest top weekly score percentage", "of weeks", RecordCategory.League, RecordSentiment.Fame, "/record-icons/HighestTopWeekPercentageLeague.webp", true)]
        HighestPercentageTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Least losses", "losses", RecordCategory.League, RecordSentiment.Fame, "/record-icons/LeastLossesLeague.webp")]
        LeastLossesLeagueHistory,

        [RecordMetadata("Least points allowed", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/LeastPointsAllowedLeague.webp")]
        LeastPointsAllowedLeagueHistory,

        [RecordMetadata("Least points allowed per week", "points", RecordCategory.League, RecordSentiment.Fame, "/record-icons/LeastPointsAllowedPerWeekLeague.webp")]
        LeastAveragePointsAllowedPerWeekLeagueHistory,

        // ==================== Shame LEAGUE ====================
        [RecordMetadata("Most last places", "last places", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostLastPlacesLeague.webp")]
        MostLastPlacesLeagueHistory,

        [RecordMetadata("Highest last place percentage", "of seasons", RecordCategory.League, RecordSentiment.Shame, "/record-icons/HighestLastPlacePercentageLeague.webp", true)]
        HighestLastPlacePercentageLeagueHistory,

        [RecordMetadata("Most losses", "losses", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostLossesLeague.webp")]
        MostLossesLeagueHistory,

        [RecordMetadata("Lowest win percentage", "of weeks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LowestWinPercentageLeague.webp", true)]
        LowestWinPercentageLeagueHistory,

        [RecordMetadata("Most losing seasons", "seasons", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostLosingSeasonsLeague.webp")]
        MostSeasonsLosingRecordLeagueHistory,

        [RecordMetadata("Highest losing season percentage", "of seasons", RecordCategory.League, RecordSentiment.Shame, "/record-icons/HighestLosingSeasonPercentageLeague.webp", true)]
        HighestLosingRecordPercentageLeagueHistory,

        [RecordMetadata("Most points allowed", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostPointsAllowedLeague.webp")]
        MostPointsAllowedLeagueHistory,

        [RecordMetadata("Most average points allowed per week", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostPointsAllowedPerWeekLeague.webp")]
        MostAveragePointsAllowedPerWeekLeagueHistory,

        [RecordMetadata("Most poor performances", "snoozers", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostPoorLeague.webp")]
        MostPoorPerformancesLeagueHistory,

        [RecordMetadata("Most blowout losses", "beatdowns", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostBlowoutLossesLeague.webp")]
        MostBlowoutLossesLeagueHistory,

        [RecordMetadata("Most narrow losses", "heart breaks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostNarrowLossesLeague.webp")]
        MostNarrowLossesLeagueHistory,

        [RecordMetadata("Most bottom weekly scores", "weeks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/MostBottomWeeksLeague.webp")]
        MostLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest bottom weekly score percentage", "of weeks", RecordCategory.League, RecordSentiment.Shame, "/record-icons/HighestBottomWeekPercentageLeague.webp", true)]
        HighestPercentageLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Least wins", "wins", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LeastWinsLeague.webp")]
        LeastWinsLeagueHistory,

        [RecordMetadata("Least points", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LeastPointsLeague.webp")]
        LeastPointsLeagueHistory,

        [RecordMetadata("Least points per week", "points", RecordCategory.League, RecordSentiment.Shame, "/record-icons/LeastPointsPerWeekLeague.webp")]
        LeastAveragePointsPerWeekLeagueHistory,

        // ==================== Fame SEASONAL ====================
        [RecordMetadata("Most points", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostPointsSeason.webp")]
        MostPointsSingleSeason,

        [RecordMetadata("Most points per week", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostAvgPointsSeason.webp")]
        MostPointsPerWeekSingleSeason,

        [RecordMetadata("Least points allowed", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/LeastPointsAllowedSeason.webp")]
        LeastPointsAllowedSingleSeason,

        [RecordMetadata("Least points allowed per week", "points", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/LeastAvgPointsAllowedSeason.webp")]
        LeastPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most wins", "wins", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostWinsSeason.webp")]
        MostWinsSingleSeason,

        [RecordMetadata("Most outstanding performances", "monster weeks", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostOutstandingSeason.webp")]
        MostOutstandingPerformancesSingleSeason,

        [RecordMetadata("Most blowout wins", "blowouts", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostBlowoutWinsSeason.webp")]
        MostBlowoutWinsSingleSeason,

        [RecordMetadata("Most narrow wins", "heart attacks", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostNarrowWinsSeason.webp")]
        MostNarrowWinsSingleSeason,

        [RecordMetadata("Most top scoring weeks", "weeks", RecordCategory.Season, RecordSentiment.Fame, "/record-icons/MostTopWeeksSeason.webp")]
        MostHighestScoringWeeksSingleSeason,

        // ==================== Shame SEASONAL ====================
        [RecordMetadata("Least points", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/LeastPointsSeason.webp")]
        LeastPointsSingleSeason,

        [RecordMetadata("Least points per week", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/LeastAvgPointsSeason.webp")]
        LeastPointsPerWeekSingleSeason,

        [RecordMetadata("Most points allowed", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostPointsAllowedSeason.webp")]
        MostPointsAllowedSingleSeason,

        [RecordMetadata("Most points allowed per week", "points", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostAvgPointsAllowedSeason.webp")]
        MostPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most losses", "losses", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostLossesSeason.webp")]
        MostLossesSingleSeason,

        [RecordMetadata("Most poor performances", "snoozers", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostPoorSeason.webp")]
        MostPoorPerformancesSingleSeason,

        [RecordMetadata("Most blowout losses", "beatdowns", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostBlowoutLossesSeason.webp")]
        MostBlowoutLossesSingleSeason,

        [RecordMetadata("Most narrow losses", "heartbreaks", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostNarrowLossesSeason.webp")]
        MostNarrowLossesSingleSeason,

        [RecordMetadata("Most bottom scoring weeks", "weeks", RecordCategory.Season, RecordSentiment.Shame, "/record-icons/MostBottomWeeksSeason.webp")]
        MostLowestScoringWeeksSingleSeason,

        // ==================== Fame WEEKLY ====================
        [RecordMetadata("Most points", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/MostPointsWeek.webp")]
        MostPointsSingleWeek,

        [RecordMetadata("Most points (playoffs)", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/MostPointsPlayoffWeek.webp")]
        MostPointsSinglePlayoffWeek,

        [RecordMetadata("Largest margin of victory", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/LargestMarginWeek.webp")]
        LargestMarginOfVictorySingleWeek,

        [RecordMetadata("Largest margin of victory (playoffs)", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/LargestMarginPlayoffWeek.webp")]
        LargestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Lowest scoring win", "points", RecordCategory.Week, RecordSentiment.Fame, "/record-icons/LowestScoringWinWeek.webp")]
        LowestScoringWinSingleWeek,

        // ==================== Shame WEEKLY ====================
        [RecordMetadata("Least points", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/LeastPointsWeek.webp")]
        LeastPointsSingleWeek,

        [RecordMetadata("Least points (playoffs)", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/LeastPointsPlayoffWeek.webp")]
        LeastPointsSinglePlayoffWeek,

        [RecordMetadata("Smallest margin of victory", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/SmallestMarginWeek.webp")]
        LowestMarginOfVictorySingleWeek,

        [RecordMetadata("Smallest margin of victory (playoffs)", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/SmallestMarginPlayoffWeek.webp")]
        LowestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Highest scoring loss", "points", RecordCategory.Week, RecordSentiment.Shame, "/record-icons/HighestScoringLossWeek.webp")]
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
        League,
        Season,
        Week,
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
