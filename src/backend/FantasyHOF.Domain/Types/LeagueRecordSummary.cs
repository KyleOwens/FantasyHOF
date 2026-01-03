using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.Domain.Types.Views;
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
        public required LeagueValueRecord MostWinsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord LeastLossesLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestWinPercentageLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostTopWeeklyScoresLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestPercentageTopWeeklyScoresLeagueHisotry { get; init; } = null!;
        public required LeagueValueRecord MostBlowoutWinsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostNarrowWinsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostChampionshipsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestChampionshipPercentageLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostSeasonsWinningRecordLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestWinningRecordPercentageLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostOutstandingPerformancesLeagueHistory { get; init; } = null!;


        //// Bad League
        public required LeagueValueRecord LeastPointsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord LeastAveragePointsPerWeekLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostPointsAllowedLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostAveragePointsAllowedPerWeekLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord LeastWinsLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostLossesLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord LowestWinPercentageLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostLowestWeeklyScoresLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestPercentageLowestWeeklyScoresLeagueHisotry { get; init; } = null!;
        public required LeagueValueRecord MostBlowoutLossesLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostNarrowLossesLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostLastPlacesLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestLastPlacePercentageLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostSeasonsLosingRecordLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord HighestLosingRecordPercentageLeagueHistory { get; init; } = null!;
        public required LeagueValueRecord MostPoorPerformancesLeagueHistory { get; init; } = null!;

        // Good Seasonal
        public required SeasonalValueRecord MostPointsSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostPointsPerWeekSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord LeastPointsAllowedSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord LeastPointsAllowedPerWeekSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostWinsSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostHighestScoringWeeksSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostBlowoutWinsSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostNarrowWinsSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostOutstandingPerformancesSingleSeason { get; init; } = null!;

        // Bad Seasonal
        public required SeasonalValueRecord LeastPointsSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord LeastPointsPerWeekSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostPointsAllowedSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostPointsAllowedPerWeekSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostLossesSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostLowestScoringWeeksSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostBlowoutLossesSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostNarrowLossesSingleSeason { get; init; } = null!;
        public required SeasonalValueRecord MostPoorPerformancesSingleSeason { get; init; } = null!;

        // Good Weekly
        public required WeeklyValueRecord MostPointsSingleWeek { get; init; } = null!;
        public required WeeklyValueRecord MostPointsSinglePlayoffWeek { get; init; } = null!;
        public required WeeklyValueRecord LargestMarginOfVictorySingleWeek { get; init; } = null!;
        public required WeeklyValueRecord LargestMarginOfVictorySinglePlayoffWeek { get; init; } = null!;
        public required WeeklyValueRecord LowestScoringWinSingleWeek { get; init; } = null!;

        // Bad Weekly
        public required WeeklyValueRecord LeastPointsSingleWeek { get; init; } = null!;
        public required WeeklyValueRecord LeastPointsSinglePlayoffWeek { get; init; } = null!;
        public required WeeklyValueRecord LowestMarginOfVictorySingleWeek { get; init; } = null!;
        public required WeeklyValueRecord LowestMarginOfVictorySinglePlayoffWeek { get; init; } = null!;
        public required WeeklyValueRecord HighestScoringLossSingleWeek { get; init; } = null!;

        public static LeagueRecordSummary? FromAggregateLeagueStats(
            IReadOnlyList<LeagueMemberAggregatedStats> allTimeStatsByMember,
            IReadOnlyList<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason,
            IReadOnlyList<WeeklyAggregationData> weeklyAggregationData)
        {
            IReadOnlyList<WeeklyAggregationData> weeklyPlayoffAggregationData = weeklyAggregationData
                .Where(x => x.MatchupTypeId != MatchupTypeId.RegularSeason && x.MatchupTypeId != MatchupTypeId.Unknown)
                .ToList();
            
            return new()
            {
                // Good League
                MostPointsLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.PointsFor),
                MostAveragePointsPerWeekLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.PointsForAverage),
                LeastPointsAllowedLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.PointsAgainst),
                LeastAveragePointsAllowedPerWeekLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.PointsAgainstAverage),
                MostWinsLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.Wins),
                LeastLossesLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.Losses),
                HighestWinPercentageLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.WinPercentage),
                MostTopWeeklyScoresLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.TopWeeks),
                HighestPercentageTopWeeklyScoresLeagueHisotry = ToMaxLeagueRecord(allTimeStatsByMember, x => x.TopWeekPercentage),
                MostBlowoutWinsLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.BlowoutWins),
                MostNarrowWinsLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.NarrowWins),
                MostChampionshipsLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.Championships),
                HighestChampionshipPercentageLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.ChampionshipPercentage),
                MostSeasonsWinningRecordLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.WinningSeasons),
                HighestWinningRecordPercentageLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.WinningSeasonPercentage),
                MostOutstandingPerformancesLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.OutstandingPerformances),

                // Bad League
                LeastPointsLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.PointsFor),
                LeastAveragePointsPerWeekLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.PointsForAverage),
                MostPointsAllowedLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.PointsAgainst),
                MostAveragePointsAllowedPerWeekLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.PointsAgainstAverage),
                LeastWinsLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.Wins),
                MostLossesLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.Losses),
                LowestWinPercentageLeagueHistory = ToMinLeagueRecord(allTimeStatsByMember, x => x.WinPercentage),
                MostLowestWeeklyScoresLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.BottomWeeks),
                HighestPercentageLowestWeeklyScoresLeagueHisotry = ToMaxLeagueRecord(allTimeStatsByMember, x => x.BottomWeekPercentage),
                MostBlowoutLossesLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.BlowoutLosses),
                MostNarrowLossesLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.NarrowLosses),
                MostLastPlacesLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.LastPlaces),
                HighestLastPlacePercentageLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.LastPlacePercentage),
                MostSeasonsLosingRecordLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.LosingSeasons),
                HighestLosingRecordPercentageLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.LosingSeasonPercentage),
                MostPoorPerformancesLeagueHistory = ToMaxLeagueRecord(allTimeStatsByMember, x => x.PoorPerformances),

                // Good Seasonal
                MostPointsSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.PointsFor),
                MostPointsPerWeekSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.PointsForAverage),
                LeastPointsAllowedSingleSeason = ToMinSeasonalRecord(statsByMemberAndSeason, x => x.PointsAgainst),
                LeastPointsAllowedPerWeekSingleSeason = ToMinSeasonalRecord(statsByMemberAndSeason, x => x.PointsAgainstAverage),
                MostWinsSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.Wins),
                MostHighestScoringWeeksSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.TopWeeks),
                MostBlowoutWinsSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.BlowoutWins),
                MostNarrowWinsSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.NarrowWins),
                MostOutstandingPerformancesSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.OutstandingPerformances),

                // Bad Seasonal
                LeastPointsSingleSeason = ToMinSeasonalRecord(statsByMemberAndSeason, x => x.PointsFor),
                LeastPointsPerWeekSingleSeason = ToMinSeasonalRecord(statsByMemberAndSeason, x => x.PointsForAverage),
                MostPointsAllowedSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.PointsAgainst),
                MostPointsAllowedPerWeekSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.PointsAgainstAverage),
                MostLossesSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.Losses),
                MostLowestScoringWeeksSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.BottomWeeks),
                MostBlowoutLossesSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.BlowoutLosses),
                MostNarrowLossesSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.NarrowLosses),
                MostPoorPerformancesSingleSeason = ToMaxSeasonalRecord(statsByMemberAndSeason, x => x.PoorPerformances),

                // Good Weekly
                MostPointsSingleWeek = ToMaxWeeklyRecord(weeklyAggregationData, x => x.Score),
                MostPointsSinglePlayoffWeek = ToMaxWeeklyRecord(weeklyPlayoffAggregationData, x => x.Score),
                LargestMarginOfVictorySingleWeek = ToMaxWeeklyRecord(weeklyAggregationData, x => x.ScoreMargin),
                LargestMarginOfVictorySinglePlayoffWeek = ToMaxWeeklyRecord(weeklyPlayoffAggregationData, x => x.ScoreMargin),
                LowestScoringWinSingleWeek = ToMinWeeklyRecord(weeklyAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Win).ToList(), x => x.Score),

                // Bad Weekly
                LeastPointsSingleWeek = ToMinWeeklyRecord(weeklyAggregationData, x => x.Score),
                LeastPointsSinglePlayoffWeek = ToMinWeeklyRecord(weeklyPlayoffAggregationData, x => x.Score),
                LowestMarginOfVictorySingleWeek = ToMinWeeklyRecord(weeklyAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Win).ToList(), x => x.ScoreMargin),
                LowestMarginOfVictorySinglePlayoffWeek = ToMinWeeklyRecord(weeklyPlayoffAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Win).ToList(), x => x.ScoreMargin),
                HighestScoringLossSingleWeek = ToMaxWeeklyRecord(weeklyAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Loss).ToList(), x => x.Score),
            };
        }

        private static LeagueValueRecord ToMaxLeagueRecord(
            IReadOnlyList<LeagueMemberAggregatedStats> allTimeStats,
            Func<LeagueMemberAggregatedStats, decimal> valueSelector)
        {
            LeagueMemberAggregatedStats stat = allTimeStats.MaxBy(stat => valueSelector(stat))!;
            return new LeagueValueRecord(stat.Member, valueSelector(stat));
        }

        private static LeagueValueRecord ToMinLeagueRecord(
            IReadOnlyList<LeagueMemberAggregatedStats> allTimeStats,
            Func<LeagueMemberAggregatedStats, decimal> valueSelector)
        {
            LeagueMemberAggregatedStats stat = allTimeStats.MinBy(stat => valueSelector(stat))!;
            return new LeagueValueRecord(stat.Member, valueSelector(stat));
        }

        private static SeasonalValueRecord ToMaxSeasonalRecord(
            IReadOnlyList<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason,
            Func<LeagueSeasonMemberAggregatedStats, decimal> valueSelector)
        {
            LeagueSeasonMemberAggregatedStats stat = statsByMemberAndSeason.MaxBy(stat => valueSelector(stat))!;
            return new SeasonalValueRecord(stat.Member, stat.Year, valueSelector(stat));
        }

        private static SeasonalValueRecord ToMinSeasonalRecord(
            IReadOnlyList<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason,
            Func<LeagueSeasonMemberAggregatedStats, decimal> valueSelector)
        {
            LeagueSeasonMemberAggregatedStats stat = statsByMemberAndSeason.MinBy(stat => valueSelector(stat))!;
            return new SeasonalValueRecord(stat.Member, stat.Year, valueSelector(stat));
        }

        private static WeeklyValueRecord ToMaxWeeklyRecord(
            IReadOnlyList<WeeklyAggregationData> weeklyAggregationData,
            Func<WeeklyAggregationData, decimal> valueSelector)
        {
            WeeklyAggregationData stat = weeklyAggregationData.MaxBy(stat => valueSelector(stat))!;
            return new WeeklyValueRecord(stat.Member, stat.Year, stat.Week, valueSelector(stat));
        }

        private static WeeklyValueRecord ToMinWeeklyRecord(
            IReadOnlyList<WeeklyAggregationData> weeklyAggregationData,
            Func<WeeklyAggregationData, decimal> valueSelector)
        {
            WeeklyAggregationData stat = weeklyAggregationData.MinBy(stat => valueSelector(stat))!;
            return new WeeklyValueRecord(stat.Member, stat.Year, stat.Week, valueSelector(stat));
        }

        //private static LeagueRecordSummary FromSingleMemberAggregateStats(LeagueSeasonMemberAggregateStats aggregateStats)
        //{
        //    return new()
        //    {
        //        // Good League
        //        MostPointsLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsFor),
        //        MostAveragePointsPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsForAverage),
        //        LeastPointsAllowedLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsAgainst),
        //        LeastAveragePointsAllowedPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsAgainstAverage),
        //        MostWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.Wins),
        //        LeastLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.Losses),
        //        HighestWinPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.WinPercentage),
        //        MostTopWeeklyScoresLeagueHistory = new(aggregateStats.Member, aggregateStats.TopWeeks),
        //        HighestPercentageTopWeeklyScoresLeagueHisotry = new(aggregateStats.Member, aggregateStats.TopWeekPercentage),
        //        MostBlowoutWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.BlowoutWins),
        //        MostNarrowWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.NarrowWins),
        //        MostChampionshipsLeagueHistory = new(aggregateStats.Member, aggregateStats.Championships),
        //        HighestChampionshipPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.ChampionshipPercentage),
        //        MostSeasonsWinningRecordLeagueHistory = new(aggregateStats.Member, aggregateStats.WinningSeasons),
        //        HighestWinningRecordPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.WinningSeasonPercentage),
        //        MostOutstandingPerformancesLeagueHistory = new(aggregateStats.Member, aggregateStats.OutstandingPerformances),

        //        // Bad League
        //        LeastPointsLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsFor),
        //        LeastAveragePointsPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsForAverage),
        //        MostPointsAllowedLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsAgainst),
        //        MostAveragePointsAllowedPerWeekLeagueHistory = new(aggregateStats.Member, aggregateStats.PointsAgainstAverage),
        //        LeastWinsLeagueHistory = new(aggregateStats.Member, aggregateStats.Wins),
        //        MostLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.Losses),
        //        LowestWinPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.WinPercentage),
        //        MostLowestWeeklyScoresLeagueHistory = new(aggregateStats.Member, aggregateStats.LowestWeeks),
        //        HighestPercentageLowestWeeklyScoresLeagueHisotry = new(aggregateStats.Member, aggregateStats.LowestWeekPercentage),
        //        MostBlowoutLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.BlowoutLosses),
        //        MostNarrowLossesLeagueHistory = new(aggregateStats.Member, aggregateStats.NarrowLosses),
        //        MostLastPlacesLeagueHistory = new(aggregateStats.Member, aggregateStats.LastPlaces),
        //        HighestLastPlacePercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.LastPlacePercentage),
        //        MostSeasonsLosingRecordLeagueHistory = new(aggregateStats.Member, aggregateStats.LosingSeasons),
        //        HighestLosingRecordPercentageLeagueHistory = new(aggregateStats.Member, aggregateStats.LosingSeasonPercentage),
        //        MostPoorPerformancesLeagueHistory = new(aggregateStats.Member, aggregateStats.PoorPerformances)
        //    };
        //}
    }
}
