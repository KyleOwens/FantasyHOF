using FantasyHOF.Application.Types.Queries.Records;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace FantasyHOF.Application.Enums
{
    public enum RecordTypeId
    {
        // ==================== Fame LEAGUE ====================
        [RecordMetadata("Most championships", "All-time leader in league championships won. If you’re on top here, you’ve got the hardware to prove it.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.Championships, RecordMetricType.Scalar,
            "/record-icons/MostChampionships.webp")]
        MostChampionshipsLeagueHistory,

        [RecordMetadata("Highest championship percentage", "Your league's most feared member. Measure of who is most efficient at turning a season into a championship.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.ChampionshipPercentage, RecordMetricType.Ratio,
            "/record-icons/HighestChampPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.Championships, RecordMetricId.Seasons)]
        HighestChampionshipPercentageLeagueHistory,

        [RecordMetadata("Most wins", "Your league's biggest winner. Measure of who has produced the most matchup wins in league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.Wins, RecordMetricType.Scalar,
            "/record-icons/MostWins.webp")]
        MostWinsLeagueHistory,

        [RecordMetadata("Highest win percentage", "Your league's most consistent winner. Measure of who is most efficient at turning a matchup into a win.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.WinPercentage, RecordMetricType.Ratio,
            "/record-icons/HighestWinPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.Wins, RecordMetricId.Weeks)]
        HighestWinPercentageLeagueHistory,

        [RecordMetadata("Most winning seasons", "Your league’s perennial contender. Measures who has the most seasons finishing with a winning record.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.WinningSeasons, RecordMetricType.Scalar,
            "/record-icons/MostWinningSeasons.webp")]
        MostSeasonsWinningRecordLeagueHistory,

        [RecordMetadata("Highest winning season percentage", "Your league’s best year-to-year success rate. Measures who is most efficient at producing winning seasons.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.WinningSeasonPercentage, RecordMetricType.Ratio,
            "/record-icons/HighestWinningSeasonPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.WinningSeasons, RecordMetricId.Seasons)]
        HighestWinningRecordPercentageLeagueHistory,

        [RecordMetadata("Most points", "Your league’s biggest point producer of all time. Measures total points scored across league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.PointsFor, RecordMetricType.Scalar,
            "/record-icons/MostPoints.webp")]
        MostPointsLeagueHistory,

        [RecordMetadata("Most points per week", "Your league’s highest weekly scorer. Measures average points scored per matchup across league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar,
            "/record-icons/MostPointsPerWeek.webp")]
        MostAveragePointsPerWeekLeagueHistory,

        [RecordMetadata("Most outstanding performances", "Your league's most likely candidate for a massive week. Measures the number of times a member has scored over 200 across league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.OutstandingPerformances, RecordMetricType.Scalar,
            "/record-icons/MostOutstanding.webp")]
        MostOutstandingPerformancesLeagueHistory,

        [RecordMetadata("Most blowout wins", "Your league's most ruthless member. Measures the number of times a member has defeated an opponent by more than 50 points.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.BlowoutWins, RecordMetricType.Scalar,
            "/record-icons/MostBlowoutWins.webp")]
        MostBlowoutWinsLeagueHistory,

        [RecordMetadata("Most narrow wins", "Your league's king of close calls. Measures how many wins were decided by less than 3 points across league history.", RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.NarrowWins, RecordMetricType.Scalar,
            "/record-icons/MostNarrowWins.webp")]
        MostNarrowWinsLeagueHistory,

        [RecordMetadata("Most top weekly scores", "Your league's weekly standout. Measures how many times a member finished as the highest scorer in a week across league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.TopWeeks, RecordMetricType.Scalar,
            "/record-icons/MostTopWeeks.webp")]
        MostTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest top weekly score percentage", "Your league's most consistent producer. Measures what percentage of weeks a member scores the most points.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.TopWeekPercentage, RecordMetricType.Ratio,
            "/record-icons/HighestTopWeekPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.TopWeeks, RecordMetricId.Weeks)]
        HighestPercentageTopWeeklyScoresLeagueHistory,

        [RecordMetadata("Least losses", "Your league's smallest loser. Measure of how many losses a member has across league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.Losses, RecordMetricType.Scalar,
            "/record-icons/LeastLosses.webp",
            SortDirection.Ascending)]
        LeastLossesLeagueHistory,

        [RecordMetadata("Least points allowed", "Your league's best bad luck charm. Measures the fewest number of points scored against a member in league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar,
            "/record-icons/LeastPointsAllowed.webp",
            SortDirection.Ascending)]
        LeastPointsAllowedLeagueHistory,

        [RecordMetadata("Least points allowed per week", "Your league's luckiest member. Measures the lowest weekly average points scored against a member in league history.",
            RecordCategoryId.League, RecordSentiment.Fame,
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Ratio,
            "/record-icons/LeastPointsAllowedPerWeek.webp",
            SortDirection.Ascending)]
        [RatioRecordMetadata(RecordMetricId.PointsAgainst, RecordMetricId.Weeks)]
        LeastAveragePointsAllowedPerWeekLeagueHistory,

        // ==================== Shame LEAGUE ====================
        [RecordMetadata("Most last places", "Your league's biggest laughing stock. Measures total last-place finishes across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.LastPlaces, RecordMetricType.Scalar,
            "/record-icons/MostLastPlaces.webp")]
        MostLastPlacesLeagueHistory,

        [RecordMetadata("Highest last place percentage", "Your league's least feared member. Measure of who is most efficient at turning a season into a last-place finish.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.LastPlacePercentage, RecordMetricType.Ratio,
            "/record-icons/HighestLastPlacePercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.LastPlaces, RecordMetricId.Seasons)]
        HighestLastPlacePercentageLeagueHistory,

        [RecordMetadata("Most losses", "Your league's biggest loser. Measures the largest number of losses in league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.Losses, RecordMetricType.Scalar,
            "/record-icons/MostLosses.webp")]
        MostLossesLeagueHistory,

        [RecordMetadata("Lowest win percentage", "Your league's most efficient loser. Measures of who is most likely to turn a matchup into a loss.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.WinPercentage, RecordMetricType.Ratio,
            "/record-icons/LowestWinPercentage.webp",
            SortDirection.Ascending)]
        [RatioRecordMetadata(RecordMetricId.Wins, RecordMetricId.Weeks)]
        LowestWinPercentageLeagueHistory,

        [RecordMetadata("Most losing seasons", "Your league’s perennial tank job. Measures who has the most seasons with a losing record.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.LosingSeasons, RecordMetricType.Scalar,
            "/record-icons/MostLosingSeasons.webp")]
        MostSeasonsLosingRecordLeagueHistory,

        [RecordMetadata("Highest losing season percentage", "Your league's worst year-to-year success rate. Measures which member is most likely to produce a losing season.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.LosingSeasonPercentage, RecordMetricType.Ratio,
            "/record-icons/HighestLosingSeasonPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.LosingSeasons, RecordMetricId.Seasons)]
        HighestLosingRecordPercentageLeagueHistory,

        [RecordMetadata("Most points allowed", "Your league's best good luck charm. Measures which member has allowed the most points against them across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar,
            "/record-icons/MostPointsAllowed.webp")]
        MostPointsAllowedLeagueHistory,

        [RecordMetadata("Most points allowed per week", "Your league's most unlucky member. Measures the highest points allowed per week across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Scalar,
            "/record-icons/MostPointsAllowedPerWeek.webp")]
        MostAveragePointsAllowedPerWeekLeagueHistory,

        [RecordMetadata("Most poor performances", "Your league's most likely candidate to have an embarrassing week. Measures the number of times a member has scored under 100 points in a week across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.PoorPerformances, RecordMetricType.Scalar,
            "/record-icons/MostPoor.webp")]
        MostPoorPerformancesLeagueHistory,

        [RecordMetadata("Most blowout losses", "Your league's most beatup member. Measures the number of times a member has lost by more than 50 points.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.BlowoutLosses, RecordMetricType.Scalar,
            "/record-icons/MostBlowoutLosses.webp")]
        MostBlowoutLossesLeagueHistory,

        [RecordMetadata("Most narrow losses", "Your league's heartbreak specialist. Measuures the number of times a member has lost by less than 3 points across league history",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.NarrowLosses, RecordMetricType.Scalar,
            "/record-icons/MostNarrowLosses.webp")]
        MostNarrowLossesLeagueHistory,

        [RecordMetadata("Most bottom weekly scores", "Your league's weekly disappointment. Measures the number of times a member has scored the least points in a week.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.BottomWeeks, RecordMetricType.Scalar,
            "/record-icons/MostBottomWeeks.webp")]
        MostLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Highest bottom weekly score percentage", "Your league's most consistent letdown. Measures who is most likely to score the least amoun of points in a week.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.BottomWeekPercentage, RecordMetricType.Ratio,
            "/record-icons/HighestBottomWeekPercentage.webp")]
        [RatioRecordMetadata(RecordMetricId.BottomWeeks, RecordMetricId.Weeks)]
        HighestPercentageLowestWeeklyScoresLeagueHistory,

        [RecordMetadata("Least wins", "Your league's saddest member. Measures who has won the least times across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.Wins, RecordMetricType.Scalar,
            "/record-icons/LeastWins.webp",
            SortDirection.Ascending)]
        LeastWinsLeagueHistory,

        [RecordMetadata("Least points", "Your league's smallest point producer. Measures the fewest total points scored across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.PointsFor, RecordMetricType.Scalar,
            "/record-icons/LeastPoints.webp",
            SortDirection.Ascending)]
        LeastPointsLeagueHistory,

        [RecordMetadata("Least points per week", "Your league's worst scorer. Measures lowest average points scored per week by a member across league history.",
            RecordCategoryId.League, RecordSentiment.Shame,
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar,
            "/record-icons/LeastPointsPerWeek.webp",
            SortDirection.Ascending)]
        LeastAveragePointsPerWeekLeagueHistory,

        // ==================== Fame SEASONAL ====================
        [RecordMetadata("Most points", "Your league's best single-season point performance. Measures the most total points scored in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.PointsFor, RecordMetricType.Scalar,
            "/record-icons/MostPoints.webp")]
        MostPointsSingleSeason,

        [RecordMetadata("Most points per week", "Your league's best weekly single-season point producer. Measures the most points scored per week in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar,
            "/record-icons/MostPointsPerWeek.webp")]
        MostPointsPerWeekSingleSeason,

        [RecordMetadata("Least points allowed", "Your league's luckiest single-season member. Measures the lowest amount of points scored against a member in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar,
            "/record-icons/LeastPointsAllowed.webp",
            SortDirection.Ascending)]
        LeastPointsAllowedSingleSeason,

        [RecordMetadata("Least points allowed per week", "Your league's member with the easiest single-season matchups. Measures the loweset average number of points scored per week in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Scalar,
            "/record-icons/LeastPointsAllowedPerWeek.webp",
            SortDirection.Ascending)]
        LeastPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most wins", "Your league's best single-season performance. Measures the most wins achieved in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.Wins, RecordMetricType.Scalar,
            "/record-icons/MostWins.webp")]
        MostWinsSingleSeason,

        [RecordMetadata("Most outstanding performances", "Your league's most explosive single-season performance. Measures the largest number of times a member scored over 200 points in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.OutstandingPerformances, RecordMetricType.Scalar,
            "/record-icons/MostOutstanding.webp")]
        MostOutstandingPerformancesSingleSeason,

        [RecordMetadata("Most blowout wins", "Your league's biggest single-season menace. Measures the largest number of times a member has beat their opponent by over 50 points in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.BlowoutWins, RecordMetricType.Scalar,
            "/record-icons/MostBlowoutWins.webp")]
        MostBlowoutWinsSingleSeason,

        [RecordMetadata("Most narrow wins", "Your league's single-season heart attack expert. Measures the most wins for a member by less than 3 points in a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.NarrowWins, RecordMetricType.Scalar,
            "/record-icons/MostNarrowWins.webp")]
        MostNarrowWinsSingleSeason,

        [RecordMetadata("Most top scoring weeks", "Your league's most dominant single-season performance. Measures the most times a member scored the most points in a week for a single season.",
            RecordCategoryId.Season, RecordSentiment.Fame,
            RecordMetricId.TopWeeks, RecordMetricType.Scalar,
            "/record-icons/MostTopWeeks.webp")]
        MostHighestScoringWeeksSingleSeason,

        // ==================== Shame SEASONAL ====================
        [RecordMetadata("Least points", "Your league's worst single-season point producer. Measures the members with the fewest points scored in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.PointsFor, RecordMetricType.Scalar,
            "/record-icons/LeastPoints.webp",
            SortDirection.Ascending)]
        LeastPointsSingleSeason,

        [RecordMetadata("Least points per week", "Your league's worst single-season weekly scorer. Measures the lowest number of points scored per week in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.PointsForAverage, RecordMetricType.Scalar,
            "/record-icons/LeastPointsPerWeek.webp",
            SortDirection.Ascending)]
        LeastPointsPerWeekSingleSeason,

        [RecordMetadata("Most points allowed", "Your league's most unlucky season. Measures the largest number of points scored against a member in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.PointsAgainst, RecordMetricType.Scalar,
            "/record-icons/MostPointsAllowed.webp")]
        MostPointsAllowedSingleSeason,

        [RecordMetadata("Most points allowed per week", "Your league's most frustrating season. Measures the largest weekly points scored against a member in a single eseason.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.PointsAgainstAverage, RecordMetricType.Scalar,
            "/record-icons/MostPointsAllowedPerWeek.webp")]
        MostPointsAllowedPerWeekSingleSeason,

        [RecordMetadata("Most losses", "Your league's most embarrassing single-season performance. Measures the most losses endured in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.Losses, RecordMetricType.Scalar,
            "/record-icons/MostLosses.webp")]
        MostLossesSingleSeason,

        [RecordMetadata("Most poor performances", "Your league's most dud-filled season. Measures the largest number of sub-100 points performances by a member in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.PoorPerformances, RecordMetricType.Scalar,
            "/record-icons/MostPoor.webp")]
        MostPoorPerformancesSingleSeason,

        [RecordMetadata("Most blowout losses", "Your league's biggest single-season punching bag. Measures the most amount of times a member lost by over 50 points in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.BlowoutLosses, RecordMetricType.Scalar,
            "/record-icons/MostBlowoutLosses.webp")]
        MostBlowoutLossesSingleSeason,

        [RecordMetadata("Most narrow losses", "Your league's single-season pain specialist. Measures the largest number of times a member lost by less than 3 points in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.NarrowLosses, RecordMetricType.Scalar,
            "/record-icons/MostNarrowLosses.webp")]
        MostNarrowLossesSingleSeason,

        [RecordMetadata("Most bottom scoring weeks", "Your league's saddest single-season performance. Measures the member with the most lowest-scoring weeks in a single season.",
            RecordCategoryId.Season, RecordSentiment.Shame,
            RecordMetricId.BottomWeeks, RecordMetricType.Scalar,
            "/record-icons/MostBottomWeeks.webp")]
        MostLowestScoringWeeksSingleSeason,

        // ==================== Fame WEEKLY ====================
        [RecordMetadata("Most points", "Your league's biggest pop off. Measures the most points scoreed by a member in a single week.",
            RecordCategoryId.Week, RecordSentiment.Fame,
            RecordMetricId.Score, RecordMetricType.Scalar,
            "/record-icons/MostPoints.webp")]
        MostPointsSingleWeek,

        [RecordMetadata("Most points (playoffs)", "Your league's most timely pop offs. Measures the most points scored by a member in a single playoff week.",
            RecordCategoryId.Week, RecordSentiment.Fame,
            RecordMetricId.PlayoffScore, RecordMetricType.Scalar,
            "/record-icons/MostPointsPlayoffWeek.webp")]
        MostPointsSinglePlayoffWeek,

        [RecordMetadata("Largest margin of victory", "Your league's biggest beatdown. Measures the largest point differential in a winning matchup.",
            RecordCategoryId.Week, RecordSentiment.Fame,
            RecordMetricId.VictoryScoreMargin, RecordMetricType.Scalar,
            "/record-icons/LargestMargin.webp")]
        LargestMarginOfVictorySingleWeek,

        [RecordMetadata("Largest margin of victory (playoffs)", "Your league's most timely beatdown. Measures the largest point differential in a winning playoff matchup.", RecordCategoryId.Week, RecordSentiment.Fame,
            RecordMetricId.PlayoffVictoryScoreMargin, RecordMetricType.Scalar,
            "/record-icons/LargestMarginPlayoffWeek.webp")]
        LargestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Lowest scoring win", "Your league's luckiest win. Measure of which member won a matchup with the least amount of points",
            RecordCategoryId.Week, RecordSentiment.Fame,
            RecordMetricId.WinScore, RecordMetricType.Scalar,
            "/record-icons/LowestScoringWin.webp",
            SortDirection.Ascending)]
        LowestScoringWinSingleWeek,

        // ==================== Shame WEEKLY ====================
        [RecordMetadata("Least points", "Your league's most embarrasing performance. Measures the fewest points ever scored in a single week.",
            RecordCategoryId.Week, RecordSentiment.Shame,
            RecordMetricId.Score, RecordMetricType.Scalar,
            "/record-icons/LeastPoints.webp",
            SortDirection.Ascending)]
        LeastPointsSingleWeek,

        [RecordMetadata("Least points (playoffs)", "Your league's least timely dud. Measures the fewest points ever scored in a single playoff week.",
            RecordCategoryId.Week, RecordSentiment.Shame,
            RecordMetricId.PlayoffScore, RecordMetricType.Scalar,
            "/record-icons/LeastPointsPlayoff.webp",
            SortDirection.Ascending)]
        LeastPointsSinglePlayoffWeek,

        [RecordMetadata("Smallest margin of victory", "Your league's closest win. Measures the smallest point differential in a win.",
            RecordCategoryId.Week, RecordSentiment.Shame,
            RecordMetricId.VictoryScoreMargin, RecordMetricType.Scalar,
            "/record-icons/SmallestMargin.webp",
            SortDirection.Ascending)]
        LowestMarginOfVictorySingleWeek,

        [RecordMetadata("Smallest margin of victory (playoffs)", "Your league's biggest clutch moment. Measures the smallest ppoint differential in a playoff win.",
            RecordCategoryId.Week, RecordSentiment.Shame,
            RecordMetricId.PlayoffVictoryScoreMargin, RecordMetricType.Scalar,
            "/record-icons/SmallestMarginPlayoff.webp",
            SortDirection.Ascending)]
        LowestMarginOfVictorySinglePlayoffWeek,

        [RecordMetadata("Highest scoring loss", "Your league's most heart breaking moment. Measures the member who scored the most points in a losing effort.",
            RecordCategoryId.Week, RecordSentiment.Shame,
            RecordMetricId.LossScore, RecordMetricType.Scalar,
            "/record-icons/HighestScoringLoss.webp")]
        HighestScoringLossSingleWeek,

        // ==================== Fame PLAYER ====================
        [RecordMetadata("Most points", "Your league's most impactful player performance. Measures the most points scored by a single player in a week.",
            RecordCategoryId.Player, RecordSentiment.Fame,
            RecordMetricId.PointsScored, RecordMetricType.Scalar,
            "/record-icons/MostPointsPlayer.webp")]
        MostPointsScoredSinglePlayer,

        [RecordMetadata("Most points (non-QB)", "Your league's most impactful position player performance. Measures th emost points scored by a single non-quarterback in a week",
            RecordCategoryId.Player, RecordSentiment.Fame,
            RecordMetricId.PointsScoredNonQB, RecordMetricType.Scalar,
            "/record-icons/MostPointsNonQBPlayer.webp")]
        MostPointsScoredSingleNonQBPlayer,

        // ==================== Shame PLAYER ====================
        [RecordMetadata("Least points", "Your league's most terrible start. Measurse the player who scored the least amount of points in a single week.",
            RecordCategoryId.Player, RecordSentiment.Shame,
            RecordMetricId.PointsScored, RecordMetricType.Scalar,
            "/record-icons/LeastPointsPlayer.webp",
            SortDirection.Ascending)]
        LeastPointsScoredSinglePlayer,

        [RecordMetadata("Least Points (non-DST)", "Your league's most terrbible offensive start. Measures the offensive player who scored the least points in a single week.",
            RecordCategoryId.Player, RecordSentiment.Shame,
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
        [Display(Name = "weeks")]
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
        [Display(Name = "weeks")]
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
        public string Description { get; }
        public RecordCategoryId Category { get; }
        public RecordSentiment Sentiment { get; }
        public RecordMetricId Metric { get; }
        public RecordMetricType MetricType { get; }
        public string IconURI { get; }
        public SortDirection SortDirection { get; }

        public RecordMetadataAttribute(
            string displayName,
            string description,
            RecordCategoryId category,
            RecordSentiment sentiment,
            RecordMetricId metric,
            RecordMetricType metricType,
            string iconURI,
            SortDirection sortDirection = SortDirection.Descending)
        {
            DisplayName = displayName;
            Description = description;
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

        private static readonly Dictionary<RecordTypeId, RatioRecordMetadataAttribute?> RatioMetadataCache =
            Enum.GetValues<RecordTypeId>()
                .ToDictionary(
                    t => t,
                    t => typeof(RecordTypeId)
                        .GetField(t.ToString())!
                        .GetCustomAttribute<RatioRecordMetadataAttribute>());

        public static RecordMetadataAttribute GetMetadata(this RecordTypeId recordType) =>
            MetadataCache[recordType];

        public static RatioRecordMetadataAttribute? GetRatioMetadta(this RecordTypeId recordType) =>
            RatioMetadataCache[recordType];
    }
}
