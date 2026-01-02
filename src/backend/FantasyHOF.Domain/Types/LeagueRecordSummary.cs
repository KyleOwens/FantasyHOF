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
        public required LeagueValueRecord MostPointsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostAveragePointsPerWeekLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord LeastPointsAllowedLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord LeastAveragePointsAllowedPerWeekLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostWinsLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord LeastLossesLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestWinPercentageLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostTopWeeklyScoresLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestPercentageTopWeeklyScoresLeagueHisotry{ get; init; } = null!;
        public required LeagueValueRecord MostBlowoutWinsLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostNarrowWinsLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostChampionshipsLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestChampionshipPercentageLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostSeasonsWinningRecordLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestWinningRecordPercentageLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostOutstandingPerformancesLeagueHistory{ get; init; } = null!;


        //// Bad League
        public required LeagueValueRecord LeastPointsLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord LeastAveragePointsPerWeekLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostPointsAllowedLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostAveragePointsAllowedPerWeekLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord LeastWinsLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostLossesLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord LowestWinPercentageLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostLowestWeeklyScoresLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestPercentageLowestWeeklyScoresLeagueHisotry{ get; init; } = null!;
        public required LeagueValueRecord MostBlowoutLossesLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostNarrowLossesLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostLastPlacesLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestLastPlacePercentageLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostSeasonsLosingRecordLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord HighestLosingRecordPercentageLeagueHistory{ get; init; } = null!;
        public required LeagueValueRecord MostPoorPerformancesLeagueHistory{ get; init; } = null!;

        //// Good Seasonal
        //public required SeasonalValueRecord MostPointsSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostPointsPerWeekSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord LeastPointsAllowedSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord LeastPointsAllowedPerWeekSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostWinsSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostHighestScoringWeeksSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostBlowoutWinsSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostNarrowWinsSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostOutstandingPerformancesSingleSeason{ get; init; } = null!;

        //// Bad Seasonal
        //public required SeasonalValueRecord LeastPointsSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord LeasttPointsPerWeekSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostPointsAllowedSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostPointsAllowedPerWeekSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostLossesSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostLowestScoringWeeksSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostBlowoutLossesSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostNarrowLossesSingleSeason{ get; init; } = null!;
        //public required SeasonalValueRecord MostPoorPerformancesSingleSeason{ get; init; } = null!;

        //// Good Weekly
        //public required WeeklyValueRecord MostPointsSingleWeek{ get; init; } = null!;
        //public required WeeklyValueRecord MostPointsSinglePlayoffWeek{ get; init; } = null!;
        //public required WeeklyValueRecord LargestMarginOfVictorySingleWeek{ get; init; } = null!;
        //public required WeeklyValueRecord LargestMarginOfVictorySinglePlayoffWeek{ get; init; } = null!;

        //// Bad Weekly
        //public required WeeklyValueRecord LeastPointsSingleWeek{ get; init; } = null!;
        //public required WeeklyValueRecord LeastPointsSinglePlayoffWeek{ get; init; } = null!;
        //public required WeeklyValueRecord LowestMarginOfVictorySingleWeek{ get; init; } = null!;
        //public required WeeklyValueRecord LowestMarginOfVictorySinglePlayoffWeek{ get; init; } = null!;
        //public required WeeklyValueRecord HighestScoringLossSingleWeek{ get; init; } = null!;

        public static LeagueRecordSummary? FromAggregateStats(IReadOnlyList<LeagueMemberAggregateStats> aggregateStats)
        {
            if (aggregateStats.Count == 0) return null;

            LeagueRecordSummary summary = FromSingleMemberAggregateStats(aggregateStats[0]);

            foreach (LeagueMemberAggregateStats memberAggregateStats in aggregateStats.Skip(1))
            {
                UpdateMaxRecord(summary.MostPointsLeagueHistory, memberAggregateStats, s => s.TotalPointsFor);
                UpdateMaxRecord(summary.MostAveragePointsPerWeekLeagueHistory, memberAggregateStats, s => s.PointsForAverage);
                UpdateMinRecord(summary.LeastPointsAllowedLeagueHistory, memberAggregateStats, s => s.TotalPointsAgainst);
                UpdateMinRecord(summary.LeastAveragePointsAllowedPerWeekLeagueHistory, memberAggregateStats, s => s.PointsForAverage);
                UpdateMaxRecord(summary.MostWinsLeagueHistory, memberAggregateStats, s => s.TotalWins);
                UpdateMinRecord(summary.LeastLossesLeagueHistory, memberAggregateStats, s => s.TotalLosses);
                UpdateMaxRecord(summary.HighestWinPercentageLeagueHistory, memberAggregateStats, s => s.WinPercentage);
                UpdateMaxRecord(summary.MostTopWeeklyScoresLeagueHistory, memberAggregateStats, s => s.TopWeeks);
                UpdateMaxRecord(summary.HighestPercentageTopWeeklyScoresLeagueHisotry, memberAggregateStats, s => s.TopWeekPercentage);
                UpdateMaxRecord(summary.MostBlowoutWinsLeagueHistory, memberAggregateStats, s => s.BlowoutWins);
                UpdateMaxRecord(summary.MostNarrowWinsLeagueHistory, memberAggregateStats, s => s.NarrowWins);
                UpdateMaxRecord(summary.MostChampionshipsLeagueHistory, memberAggregateStats, s => s.Championships);
                UpdateMaxRecord(summary.HighestChampionshipPercentageLeagueHistory, memberAggregateStats, s => s.ChampionshipPercentage);
                UpdateMaxRecord(summary.MostSeasonsWinningRecordLeagueHistory, memberAggregateStats, s => s.WinningSeasons);
                UpdateMaxRecord(summary.HighestWinningRecordPercentageLeagueHistory, memberAggregateStats, s => s.WinningSeasonPercentage);
                UpdateMaxRecord(summary.MostOutstandingPerformancesLeagueHistory, memberAggregateStats, s => s.OutstandingPerformances);

                UpdateMinRecord(summary.LeastPointsLeagueHistory, memberAggregateStats, s => s.TotalPointsFor);
                UpdateMinRecord(summary.LeastAveragePointsPerWeekLeagueHistory, memberAggregateStats, s => s.PointsForAverage);
                UpdateMaxRecord(summary.MostPointsAllowedLeagueHistory, memberAggregateStats, s => s.TotalPointsAgainst);
                UpdateMaxRecord(summary.MostAveragePointsAllowedPerWeekLeagueHistory, memberAggregateStats, s => s.PointsAgainstAverage);
                UpdateMinRecord(summary.LeastWinsLeagueHistory, memberAggregateStats, s => s.TotalWins);
                UpdateMaxRecord(summary.MostLossesLeagueHistory, memberAggregateStats, s => s.TotalLosses);
                UpdateMinRecord(summary.LowestWinPercentageLeagueHistory, memberAggregateStats, s => s.WinPercentage);
                UpdateMaxRecord(summary.MostLowestWeeklyScoresLeagueHistory, memberAggregateStats, s => s.LowestWeeks);
                UpdateMaxRecord(summary.HighestPercentageLowestWeeklyScoresLeagueHisotry, memberAggregateStats, s => s.LowestWeekPercentage);
                UpdateMaxRecord(summary.MostBlowoutLossesLeagueHistory, memberAggregateStats, s => s.BlowoutLosses);
                UpdateMaxRecord(summary.MostNarrowLossesLeagueHistory, memberAggregateStats, s => s.NarrowLosses);
                UpdateMaxRecord(summary.MostLastPlacesLeagueHistory, memberAggregateStats, s => s.LastPlaces);
                UpdateMaxRecord(summary.HighestLastPlacePercentageLeagueHistory, memberAggregateStats, s => s.LastPlacePercentage);
                UpdateMaxRecord(summary.MostSeasonsLosingRecordLeagueHistory, memberAggregateStats, s => s.LosingSeasons);
                UpdateMaxRecord(summary.HighestLosingRecordPercentageLeagueHistory, memberAggregateStats, s => s.LosingSeasonPercentage);
                UpdateMaxRecord(summary.MostPoorPerformancesLeagueHistory, memberAggregateStats, s => s.PoorPerformances);
            }

            return summary;
        }

        private static LeagueRecordSummary FromSingleMemberAggregateStats(LeagueMemberAggregateStats aggregateStats)
        {
            return new()
            {
                // Good League
                MostPointsLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalPointsFor),
                MostAveragePointsPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsForAverage),
                LeastPointsAllowedLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalPointsAgainst),
                LeastAveragePointsAllowedPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsAgainstAverage),
                MostWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalWins),
                LeastLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalLosses),
                HighestWinPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.WinPercentage),
                MostTopWeeklyScoresLeagueHistory = new(aggregateStats.Member, aggregateStats.TopWeeks),
                HighestPercentageTopWeeklyScoresLeagueHisotry = new(aggregateStats.Member, aggregateStats.TopWeekPercentage),
                MostBlowoutWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.BlowoutWins),
                MostNarrowWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.NarrowWins),
                MostChampionshipsLeagueHistory = new(aggregateStats.Member, aggregateStats.Championships),
                HighestChampionshipPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.ChampionshipPercentage),
                MostSeasonsWinningRecordLeagueHistory = new(aggregateStats.Member, aggregateStats.WinningSeasons),
                HighestWinningRecordPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.WinningSeasonPercentage),
                MostOutstandingPerformancesLeagueHistory = new(aggregateStats.Member, aggregateStats.OutstandingPerformances),

                // Bad League
                LeastPointsLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalPointsFor),
                LeastAveragePointsPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsForAverage),
                MostPointsAllowedLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalPointsAgainst),
                MostAveragePointsAllowedPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsAgainstAverage),
                LeastWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalWins),
                MostLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.TotalLosses),
                LowestWinPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.WinPercentage),
                MostLowestWeeklyScoresLeagueHistory = new(aggregateStats.Member, aggregateStats.LowestWeeks),
                HighestPercentageLowestWeeklyScoresLeagueHisotry = new(aggregateStats.Member, aggregateStats.LowestWeekPercentage),
                MostBlowoutLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.BlowoutLosses),
                MostNarrowLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.NarrowLosses),
                MostLastPlacesLeagueHistory = new(aggregateStats.Member, aggregateStats.LastPlaces),
                HighestLastPlacePercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.LastPlacePercentage),
                MostSeasonsLosingRecordLeagueHistory = new(aggregateStats.Member, aggregateStats.LosingSeasons),
                HighestLosingRecordPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.LosingSeasonPercentage),
                MostPoorPerformancesLeagueHistory = new(aggregateStats.Member, aggregateStats.PoorPerformances)
            };
        }

        private static void UpdateMaxRecord(
            LeagueValueRecord record,
            LeagueMemberAggregateStats stat,
            Func<LeagueMemberAggregateStats, decimal> selector)
        {
            var value = selector(stat);
            if (value > record.Value)
            {
                record.UpdateRecord(stat.Member, value);
            }
        }

        private static void UpdateMinRecord(
            LeagueValueRecord record,
            LeagueMemberAggregateStats stat,
            Func<LeagueMemberAggregateStats, decimal> selector)
        {
            var value = selector(stat);
            if (value < record.Value)
            {
                record.UpdateRecord(stat.Member, value);
            }
        }
    }
}
