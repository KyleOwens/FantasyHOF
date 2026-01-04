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
        [RecordMetadata("Most championships", RecordCategory.League, RecordSentiment.Fame, "MostChampionshipsLeague.png")]
        MostChampionshipsLeagueHistory,

        [RecordMetadata("Highest championship percentage", RecordCategory.League, RecordSentiment.Fame, "HighestChampPercentageLeague.png")]
        HighestChampionshipPercentageLeagueHistory,

        [RecordMetadata("Most wins", RecordCategory.League, RecordSentiment.Fame, "MostWinsLeague.png")]
        MostWinsLeagueHistory,

        [RecordMetadata("Highest win percentage", RecordCategory.League, RecordSentiment.Fame, "HighestWinPercentageLeague.png")]
        HighestWinPercentageLeagueHistory,

        [RecordMetadata("Most winning seasons", RecordCategory.League, RecordSentiment.Fame, "MostWinningSeasonsLeague.png")]
        MostSeasonsWinningRecordLeagueHistory,

        [RecordMetadata("Highest winning season percentage", RecordCategory.League, RecordSentiment.Fame, "HighestWinningSeasonPercentageeLeague.png")]
        HighestWinningRecordPercentageLeagueHistory,

        [RecordMetadata("Most points", RecordCategory.League, RecordSentiment.Fame, "MostPointsLeague.png")]
        MostPointsLeagueHistory,

        [RecordMetadata("Most points per week", RecordCategory.League, RecordSentiment.Fame, "MostPointsPerWeekLeague.png")]
        MostAveragePointsPerWeekLeagueHistory,

        [RecordMetadata("Most outstanding performances", RecordCategory.League, RecordSentiment.Fame, "MostOutstandingLeague.png")]
        MostOutstandingPerformancesLeagueHistory,

        [RecordMetadata("Most blowout wins", RecordCategory.League, RecordSentiment.Fame, "MostBlowoutWinsLeague.png")]
        MostBlowoutWinsLeagueHistory,

        [RecordMetadata("Most narrow wins", RecordCategory.League, RecordSentiment.Fame, "MostNarrowWinsLeague.png")]
        MostNarrowWinsLeagueHistory,

        [RecordMetadata("Most top weekly scores", RecordCategory.League, RecordSentiment.Fame, "MostTopWeeksLeague.png")]
        MostTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest top weekly score percentage", RecordCategory.League, RecordSentiment.Fame, "HighestTopWeekPercentageLeague.png")]
        HighestPercentageTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Least losses", RecordCategory.League, RecordSentiment.Fame, "LeastLossesLeague.png")]
        LeastLossesLeagueHistory,

        [RecordMetadata("Least points allowed", RecordCategory.League, RecordSentiment.Fame, "LeastPointsAllowedLeague.png")]
        LeastPointsAllowedLeagueHistory,

        [RecordMetadata("Least points allowed per week", RecordCategory.League, RecordSentiment.Fame, "LeastPointsAllowedPerWeekLeague.png")]
        LeastAveragePointsAllowedPerWeekLeagueHistory,

        // ==================== Shame LEAGUE ====================
        [RecordMetadata("Most last places", RecordCategory.League, RecordSentiment.Shame, "MostLastPlacesLeague.png")]
        MostLastPlacesLeagueHistory,

        [RecordMetadata("Highest last place percentage", RecordCategory.League, RecordSentiment.Shame, "HighestLastPlacePercentageLeague.png")]
        HighestLastPlacePercentageLeagueHistory,

        [RecordMetadata("Most losses", RecordCategory.League, RecordSentiment.Shame, "MostLossesLeague.png")]
        MostLossesLeagueHistory,

        [RecordMetadata("Lowest win percentage", RecordCategory.League, RecordSentiment.Shame, "LowestWinPercentageLeague.png")]
        LowestWinPercentageLeagueHistory,

        [RecordMetadata("Most losing Sseasons", RecordCategory.League, RecordSentiment.Shame, "MostLosingSeasonsLeague.png")]
        MostSeasonsLosingRecordLeagueHistory,

        [RecordMetadata("Highest losing season percentage", RecordCategory.League, RecordSentiment.Shame, "HighestLosingSeasonPercentageLeague.png")]
        HighestLosingRecordPercentageLeagueHistory,

        [RecordMetadata("Most points allowed", RecordCategory.League, RecordSentiment.Shame, "MostPointsAllowedLeague.png")]
        MostPointsAllowedLeagueHistory,

        [RecordMetadata("Most average points allowed per week", RecordCategory.League, RecordSentiment.Shame, "MostPointsAllowedPerWeekLeague.png")]
        MostAveragePointsAllowedPerWeekLeagueHistory,

        [RecordMetadata("Most poor performances", RecordCategory.League, RecordSentiment.Shame, "MostPoorLeague.png")]
        MostPoorPerformancesLeagueHistory,

        [RecordMetadata("Most blowout losses", RecordCategory.League, RecordSentiment.Shame, "MostBlowoutLossesLeague.png")]
        MostBlowoutLossesLeagueHistory,

        [RecordMetadata("Most narrow losses", RecordCategory.League, RecordSentiment.Shame, "MostNarrowLossesLeague.png")]
        MostNarrowLossesLeagueHistory,

        [RecordMetadata("Most bottom weekly scores", RecordCategory.League, RecordSentiment.Shame, "MostBottomWeeksLeague.png")]
        MostLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest bottom weekly score percentage", RecordCategory.League, RecordSentiment.Shame, "HighestBottomWeekPercentageLeague.png")]
        HighestPercentageLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Least wins", RecordCategory.League, RecordSentiment.Shame, "LeastWinsLeague.png")]
        LeastWinsLeagueHistory,

        [RecordMetadata("Least points", RecordCategory.League, RecordSentiment.Shame, "LeastPointsLeague.png")]
        LeastPointsLeagueHistory,

        [RecordMetadata("Least points per week", RecordCategory.League, RecordSentiment.Shame, "LeastPointsPerWeekLeague.png")]
        LeastAveragePointsPerWeekLeagueHistory,

        // ==================== Fame SEASONAL ====================
        [RecordMetadata("Most points", RecordCategory.Season, RecordSentiment.Fame, "MostPointsSeason.png")]
        MostPointsSingleSeason,

        [RecordMetadata("Most points per week", RecordCategory.Season, RecordSentiment.Fame, "MostAvgPointsSeason.png")]
        MostPointsPerWeekSingleSeason,

        [RecordMetadata("Least points allowed", RecordCategory.Season, RecordSentiment.Fame, "LeastPointsAllowedSeason.png")]
        LeastPointsAllowedSingleSeason,

        [RecordMetadata("Least points allowed per week", RecordCategory.Season, RecordSentiment.Fame, "LeastAvgPointsAllowedSeason.png")]
        LeastPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most wins", RecordCategory.Season, RecordSentiment.Fame, "MostWinsSeason.png")]
        MostWinsSingleSeason,

        [RecordMetadata("Most outstanding performances", RecordCategory.Season, RecordSentiment.Fame, "MostOutstandingSeason.png")]
        MostOutstandingPerformancesSingleSeason,

        [RecordMetadata("Most blowout wins", RecordCategory.Season, RecordSentiment.Fame, "MostBlowoutWinsSeason.png")]
        MostBlowoutWinsSingleSeason,

        [RecordMetadata("Most narrow wins", RecordCategory.Season, RecordSentiment.Fame, "MostNarrowWinsSeason.png")]
        MostNarrowWinsSingleSeason,

        [RecordMetadata("Most top scoring weeks", RecordCategory.Season, RecordSentiment.Fame, "MostTopWeeksSeason.png")]
        MostHighestScoringWeeksSingleSeason,

        // ==================== Shame SEASONAL ====================
        [RecordMetadata("Least points", RecordCategory.Season, RecordSentiment.Shame, "LeastPointsSeason.png")]
        LeastPointsSingleSeason,

        [RecordMetadata("Least points per week", RecordCategory.Season, RecordSentiment.Shame, "LeastAvgPointsSeason.png")]
        LeastPointsPerWeekSingleSeason,

        [RecordMetadata("Most points allowed", RecordCategory.Season, RecordSentiment.Shame, "MostPointsAllowedSeason.png")]
        MostPointsAllowedSingleSeason,

        [RecordMetadata("Most points allowed per week", RecordCategory.Season, RecordSentiment.Shame, "MostAvgPointsAllowedSeason.png")]
        MostPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most losses", RecordCategory.Season, RecordSentiment.Shame, "MostLossesSeason.png")]
        MostLossesSingleSeason,

        [RecordMetadata("Most poor performances", RecordCategory.Season, RecordSentiment.Shame, "MostPoorSeason.png")]
        MostPoorPerformancesSingleSeason,

        [RecordMetadata("Most blowout losses", RecordCategory.Season, RecordSentiment.Shame, "MostBlowoutLossesSeason.png")]
        MostBlowoutLossesSingleSeason,

        [RecordMetadata("Most narrow losses", RecordCategory.Season, RecordSentiment.Shame, "MostNarrowLossesSeason.png")]
        MostNarrowLossesSingleSeason,

        [RecordMetadata("Most bottom scoring weeks", RecordCategory.Season, RecordSentiment.Shame, "MostBottomWeeksSeason.png")]
        MostLowestScoringWeeksSingleSeason,

        // ==================== Fame WEEKLY ====================
        [RecordMetadata("Most points", RecordCategory.Week, RecordSentiment.Fame, "MostPointsWeek.png")]
        MostPointsSingleWeek,

        [RecordMetadata("Most points (playoffs)", RecordCategory.Week, RecordSentiment.Fame, "MostPointsPlayoffWeek.png")]
        MostPointsSinglePlayoffWeek,

        [RecordMetadata("Largest margin of victory", RecordCategory.Week, RecordSentiment.Fame, "LargestMarginWeek.png")]
        LargestMarginOfVictorySingleWeek,

        [RecordMetadata("Largest margin of victory (playoffs)", RecordCategory.Week, RecordSentiment.Fame, "LargestMarginPlayoffWeek.png")]
        LargestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Lowest scoring win", RecordCategory.Week, RecordSentiment.Fame, "LowestScoringWinWeek.png")]
        LowestScoringWinSingleWeek,

        // ==================== Shame WEEKLY ====================
        [RecordMetadata("Least points", RecordCategory.Week, RecordSentiment.Shame, "LeastPointsWeek.png")]
        LeastPointsSingleWeek,

        [RecordMetadata("Least points (playoffs)", RecordCategory.Week, RecordSentiment.Shame, "LeastPointsPlayoffWeek.png")]
        LeastPointsSinglePlayoffWeek,

        [RecordMetadata("Smallest margin of victory", RecordCategory.Week, RecordSentiment.Shame, "SmallestMarginWeek.png")]
        LowestMarginOfVictorySingleWeek,

        [RecordMetadata("Smallest margin of victory (playoffs)", RecordCategory.Week, RecordSentiment.Shame, "SmallestMarginPlayoffWeek.png")]
        LowestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Highest scoring loss", RecordCategory.Week, RecordSentiment.Shame, "HighestScoringLossWeek.png")]
        HighestScoringLossSingleWeek,

        // ==================== Fame PLAYER ====================
        [RecordMetadata("Most points", RecordCategory.Player, RecordSentiment.Fame, "MostPointsPlayer.png")]
        MostPointsScoredSinglePlayer,

        [RecordMetadata("Most points (non-QB)", RecordCategory.Player, RecordSentiment.Fame, "MostPointsNonQBPlayer.png")]
        MostPointsScoredSingleNonQBPlayer,

        // ==================== Shame PLAYER ====================
        [RecordMetadata("Least points", RecordCategory.Player, RecordSentiment.Shame, "LeastPointsPlayer.png")]
        LeastPointsScoredSinglePlayer,

        [RecordMetadata("Least Points (non-DST)", RecordCategory.Player, RecordSentiment.Shame, "LeastPointsNonDefPlayer.png")]
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
        public RecordCategory Category { get; }
        public RecordSentiment Sentiment { get; }
        public string IconURI { get; }

        public RecordMetadataAttribute(
            string displayName,
            RecordCategory category,
            RecordSentiment sentiment,
            string iconURI)
        {
            DisplayName = displayName;
            Category = category;
            Sentiment = sentiment;
            IconURI = iconURI;
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
