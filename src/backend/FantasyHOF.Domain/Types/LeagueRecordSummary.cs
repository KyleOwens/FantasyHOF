using FantasyHOF.Domain.Types.Records;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueRecordSummary
    {
        public int Id { get; private set; }
        public int LeagueId { get; private set; }

        // Good League
        public required LeagueValueRecord MostPointsLeagueHistory { get; init; }
        public required LeagueValueRecord MostAveragePointsPerWeekLeagueHistory { get; init; }
        //public required LeagueValueRecord LeastPointsAllowedLeagueHistory { get; init; }
        //public required LeagueValueRecord LeastAveragePointsAllowedPerWeekLeagueHistory { get; init; }
        //public required LeagueValueRecord MostWinsLeagueHistory { get; init; }
        //public required LeagueValueRecord LeastLossesLeagueHistory { get; init; }
        //public required LeagueValueRecord HighestWinPercentageLeagueHistory { get; init; }
        //public required LeagueValueRecord MostTopWeeklyScoresLeagueHistory { get; init; }
        //public required LeagueValueRecord HighestPercentageTopWeeklyScoresLeagueHisotry { get; init; }
        //public required LeagueValueRecord MostBlowoutWinsLeagueHistory { get; init; }
        //public required LeagueValueRecord MostNarrowWinsLeagueHistory { get; init; }
        //public required LeagueValueRecord MostChampionshipsLeagueHistory { get; init; }
        //public required LeagueValueRecord HighestChampionshipPercentageLeagueHistory { get; init; }
        //public required LeagueValueRecord MostSeasonsWinningRecordLeagueHistory { get; init; }
        //public required LeagueValueRecord HighestWinningRecordPercentageLeagueHistory { get; init; }
        //public required LeagueValueRecord MostOutstandingPerformancesLeagueHistory { get; init; }


        //// Bad League
        //public required LeagueValueRecord LeastPointsLeagueHistory { get; init; }
        //public required LeagueValueRecord LeastAveragePointsPerWeekLeagueHistory { get; init; }
        //public required LeagueValueRecord MostPointsAllowedLeagueHistory { get; init; }
        //public required LeagueValueRecord MostAveragePointsAllowedPerWeekLeagueHistory { get; init; }
        //public required LeagueValueRecord LeastWinsLeagueHistory { get; init; }
        //public required LeagueValueRecord MostLossesLeagueHistory { get; init; }
        //public required LeagueValueRecord LowestWinPercentageLeagueHistory { get; init; }
        //public required LeagueValueRecord LeastTopWeeklyScoresLeagueHistory { get; init; }
        //public required LeagueValueRecord LowestPercentageTopWeeklyScoresLeagueHisotry { get; init; }
        //public required LeagueValueRecord LeastBlowWinsLeagueHistory { get; init; }
        //public required LeagueValueRecord MostNarrowLossesLeagueHistory { get; init; }
        //public required LeagueValueRecord MostLastPlacesLeagueHistory { get; init; }
        //public required LeagueValueRecord HighestLastPlacePercentageLeagueHistory { get; init; }
        //public required LeagueValueRecord MostSeasonsLosingRecordLeagueHistory { get; init; }
        //public required LeagueValueRecord HighestLosingRecordPercentageLeagueHistory { get; init; }
        //public required LeagueValueRecord MostPoorPerformancesLeagueHistory { get; init; }

        //// Good Seasonal
        //public required SeasonalValueRecord MostPointsSingleSeason { get; init; }
        //public required SeasonalValueRecord MostPointsPerWeekSingleSeason { get; init; }
        //public required SeasonalValueRecord LeastPointsAllowedSingleSeason { get; init; }
        //public required SeasonalValueRecord LeastPointsAllowedPerWeekSingleSeason { get; init; }
        //public required SeasonalValueRecord MostWinsSingleSeason { get; init; }
        //public required SeasonalValueRecord MostHighestScoringWeeksSingleSeason { get; init; }
        //public required SeasonalValueRecord MostBlowoutWinsSingleSeason { get; init; }
        //public required SeasonalValueRecord MostNarrowWinsSingleSeason { get; init; }
        //public required SeasonalValueRecord MostOutstandingPerformancesSingleSeason { get; init; }

        //// Bad Seasonal
        //public required SeasonalValueRecord LeastPointsSingleSeason { get; init; }
        //public required SeasonalValueRecord LeasttPointsPerWeekSingleSeason { get; init; }
        //public required SeasonalValueRecord MostPointsAllowedSingleSeason { get; init; }
        //public required SeasonalValueRecord MostPointsAllowedPerWeekSingleSeason { get; init; }
        //public required SeasonalValueRecord MostLossesSingleSeason { get; init; }
        //public required SeasonalValueRecord MostLowestScoringWeeksSingleSeason { get; init; }
        //public required SeasonalValueRecord MostBlowoutLossesSingleSeason { get; init; }
        //public required SeasonalValueRecord MostNarrowLossesSingleSeason { get; init; }
        //public required SeasonalValueRecord MostPoorPerformancesSingleSeason { get; init; }

        //// Good Weekly
        //public required WeeklyValueRecord MostPointsSingleWeek { get; init; }
        //public required WeeklyValueRecord MostPointsSinglePlayoffWeek { get; init; }
        //public required WeeklyValueRecord LargestMarginOfVictorySingleWeek { get; init; }
        //public required WeeklyValueRecord LargestMarginOfVictorySinglePlayoffWeek { get; init; }

        //// Bad Weekly
        //public required WeeklyValueRecord LeastPointsSingleWeek { get; init; }
        //public required WeeklyValueRecord LeastPointsSinglePlayoffWeek { get; init; }
        //public required WeeklyValueRecord LowestMarginOfVictorySingleWeek { get; init; }
        //public required WeeklyValueRecord LowestMarginOfVictorySinglePlayoffWeek { get; init; }
        //public required WeeklyValueRecord HighestScoringLossSingleWeek { get; init; }
    }
}
