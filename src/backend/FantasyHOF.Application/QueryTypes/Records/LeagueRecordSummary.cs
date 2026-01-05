using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.Domain.Types.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueRecordSummary
    {
        public IReadOnlyList<LeagueRecord> LeagueRecords { get; }
        public IReadOnlyList<SeasonalRecord> SeasonalRecords { get; }
        public IReadOnlyList<WeeklyRecord> WeeklyRecords { get; }
        public IReadOnlyList<PlayerRecord> PlayerRecords { get; }

        public LeagueRecordSummary(
            List<LeagueRecord> leagueRecords,
            List<SeasonalRecord> seasonalRecords,
            List<WeeklyRecord> weeklyRecords,
            List<PlayerRecord> playerRecords)
        {
            LeagueRecords = leagueRecords;
            SeasonalRecords = seasonalRecords;
            WeeklyRecords = weeklyRecords;
            PlayerRecords = playerRecords;
        }

        public static LeagueRecordSummary? FromAggregateLeagueStats(
            IReadOnlyList<LeagueMemberAggregatedStats> allTimeStatsByMember,
            IReadOnlyList<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason,
            IReadOnlyList<WeeklyAggregationData> weeklyAggregationData,
            IReadOnlyList<PlayerAggregationData> playerAggregationData)
        {
            IReadOnlyList<WeeklyAggregationData> weeklyPlayoffAggregationData = weeklyAggregationData
                .Where(x => x.MatchupTypeId != MatchupTypeId.RegularSeason && x.MatchupTypeId != MatchupTypeId.Unknown)
                .ToList();

            // This could be made much more efficient by iterating over each list just one time. For now, leave for simplicity
            List<LeagueRecord> leagueRecords =
            [
                ToLeagueRecord(RecordType.MostChampionshipsLeagueHistory, allTimeStatsByMember, x => x.Championships),
                ToLeagueRecord(RecordType.HighestChampionshipPercentageLeagueHistory, allTimeStatsByMember, x => x.ChampionshipPercentage),
                ToLeagueRecord(RecordType.MostWinsLeagueHistory, allTimeStatsByMember, x => x.Wins),
                ToLeagueRecord(RecordType.HighestWinPercentageLeagueHistory, allTimeStatsByMember, x => x.WinPercentage),
                ToLeagueRecord(RecordType.MostSeasonsWinningRecordLeagueHistory, allTimeStatsByMember, x => x.WinningSeasons),
                ToLeagueRecord(RecordType.HighestWinningRecordPercentageLeagueHistory, allTimeStatsByMember, x => x.WinningSeasonPercentage),
                ToLeagueRecord(RecordType.MostPointsLeagueHistory, allTimeStatsByMember, x => x.PointsFor),
                ToLeagueRecord(RecordType.MostAveragePointsPerWeekLeagueHistory, allTimeStatsByMember, x => x.PointsForAverage),
                ToLeagueRecord(RecordType.MostOutstandingPerformancesLeagueHistory, allTimeStatsByMember, x => x.OutstandingPerformances),
                ToLeagueRecord(RecordType.MostBlowoutWinsLeagueHistory, allTimeStatsByMember, x => x.BlowoutWins),
                ToLeagueRecord(RecordType.MostNarrowWinsLeagueHistory, allTimeStatsByMember, x => x.NarrowWins),
                ToLeagueRecord(RecordType.MostTopWeeklyScoresLeagueHistory, allTimeStatsByMember, x => x.TopWeeks),
                ToLeagueRecord(RecordType.HighestPercentageTopWeeklyScoresLeagueHistory, allTimeStatsByMember, x => x.TopWeekPercentage),
                ToLeagueRecord(RecordType.LeastLossesLeagueHistory, allTimeStatsByMember, x => x.Losses, true),
                ToLeagueRecord(RecordType.LeastPointsAllowedLeagueHistory, allTimeStatsByMember, x => x.PointsAgainst, true),
                ToLeagueRecord(RecordType.LeastAveragePointsAllowedPerWeekLeagueHistory, allTimeStatsByMember, x => x.PointsAgainstAverage, true),

                ToLeagueRecord(RecordType.MostLastPlacesLeagueHistory, allTimeStatsByMember, x => x.LastPlaces),
                ToLeagueRecord(RecordType.HighestLastPlacePercentageLeagueHistory, allTimeStatsByMember, x => x.LastPlacePercentage),
                ToLeagueRecord(RecordType.MostLossesLeagueHistory, allTimeStatsByMember, x => x.Losses),
                ToLeagueRecord(RecordType.LowestWinPercentageLeagueHistory, allTimeStatsByMember, x => x.WinPercentage, true),
                ToLeagueRecord(RecordType.MostSeasonsLosingRecordLeagueHistory, allTimeStatsByMember, x => x.LosingSeasons),
                ToLeagueRecord(RecordType.HighestLosingRecordPercentageLeagueHistory, allTimeStatsByMember, x => x.LosingSeasonPercentage),
                ToLeagueRecord(RecordType.MostPointsAllowedLeagueHistory, allTimeStatsByMember, x => x.PointsAgainst),
                ToLeagueRecord(RecordType.MostAveragePointsAllowedPerWeekLeagueHistory, allTimeStatsByMember, x => x.PointsAgainstAverage),
                ToLeagueRecord(RecordType.MostPoorPerformancesLeagueHistory, allTimeStatsByMember, x => x.PoorPerformances),
                ToLeagueRecord(RecordType.MostBlowoutLossesLeagueHistory, allTimeStatsByMember, x => x.BlowoutLosses),
                ToLeagueRecord(RecordType.MostNarrowLossesLeagueHistory, allTimeStatsByMember, x => x.NarrowLosses),
                ToLeagueRecord(RecordType.MostLowestWeeklyScoresLeagueHistory, allTimeStatsByMember, x => x.BottomWeeks),
                ToLeagueRecord(RecordType.HighestPercentageLowestWeeklyScoresLeagueHistory, allTimeStatsByMember, x => x.BottomWeekPercentage),
                ToLeagueRecord(RecordType.LeastWinsLeagueHistory, allTimeStatsByMember, x => x.Wins, true),
                ToLeagueRecord(RecordType.LeastPointsLeagueHistory, allTimeStatsByMember, x => x.PointsFor, true),
                ToLeagueRecord(RecordType.LeastAveragePointsPerWeekLeagueHistory, allTimeStatsByMember, x => x.PointsForAverage, true),
            ];

            List<SeasonalRecord> seasonRecords =
            [
                ToSeasonalRecord(RecordType.MostPointsSingleSeason, statsByMemberAndSeason, x => x.PointsFor),
                ToSeasonalRecord(RecordType.MostPointsPerWeekSingleSeason, statsByMemberAndSeason, x => x.PointsForAverage),
                ToSeasonalRecord(RecordType.LeastPointsAllowedSingleSeason, statsByMemberAndSeason, x => x.PointsAgainst, true),
                ToSeasonalRecord(RecordType.LeastPointsAllowedPerWeekSingleSeason, statsByMemberAndSeason, x => x.PointsAgainstAverage, true),
                ToSeasonalRecord(RecordType.MostWinsSingleSeason, statsByMemberAndSeason, x => x.Wins),
                ToSeasonalRecord(RecordType.MostOutstandingPerformancesSingleSeason, statsByMemberAndSeason, x => x.OutstandingPerformances),
                ToSeasonalRecord(RecordType.MostBlowoutWinsSingleSeason, statsByMemberAndSeason, x => x.BlowoutWins),
                ToSeasonalRecord(RecordType.MostNarrowWinsSingleSeason, statsByMemberAndSeason, x => x.NarrowWins),
                ToSeasonalRecord(RecordType.MostHighestScoringWeeksSingleSeason, statsByMemberAndSeason, x => x.TopWeeks),

                ToSeasonalRecord(RecordType.LeastPointsSingleSeason, statsByMemberAndSeason, x => x.PointsFor, true),
                ToSeasonalRecord(RecordType.LeastPointsPerWeekSingleSeason, statsByMemberAndSeason, x => x.PointsForAverage, true),
                ToSeasonalRecord(RecordType.MostPointsAllowedSingleSeason, statsByMemberAndSeason, x => x.PointsAgainst),
                ToSeasonalRecord(RecordType.MostPointsAllowedPerWeekSingleSeason, statsByMemberAndSeason, x => x.PointsAgainstAverage),
                ToSeasonalRecord(RecordType.MostLossesSingleSeason, statsByMemberAndSeason, x => x.Losses),
                ToSeasonalRecord(RecordType.MostPoorPerformancesSingleSeason, statsByMemberAndSeason, x => x.PoorPerformances),
                ToSeasonalRecord(RecordType.MostBlowoutLossesSingleSeason, statsByMemberAndSeason, x => x.BlowoutLosses),
                ToSeasonalRecord(RecordType.MostNarrowLossesSingleSeason, statsByMemberAndSeason, x => x.NarrowLosses),
                ToSeasonalRecord(RecordType.MostLowestScoringWeeksSingleSeason, statsByMemberAndSeason, x => x.BottomWeeks),
            ];

            List<WeeklyRecord> weeklyRecords =
            [
                ToWeeklyRecord(RecordType.MostPointsSingleWeek, weeklyAggregationData, x => x.Score),
                ToWeeklyRecord(RecordType.MostPointsSinglePlayoffWeek, weeklyPlayoffAggregationData, x => x.Score),
                ToWeeklyRecord(RecordType.LargestMarginOfVictorySingleWeek, weeklyAggregationData, x => x.ScoreMargin),
                ToWeeklyRecord(RecordType.LargestMarginOfVictorySinglePlayoffWeek, weeklyPlayoffAggregationData, x => x.ScoreMargin),
                ToWeeklyRecord(RecordType.LowestScoringWinSingleWeek, weeklyAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Win), x => x.Score, true),

                ToWeeklyRecord(RecordType.LeastPointsSingleWeek, weeklyAggregationData, x => x.Score, true),
                ToWeeklyRecord(RecordType.LeastPointsSinglePlayoffWeek, weeklyPlayoffAggregationData, x => x.Score, true),
                ToWeeklyRecord(RecordType.LowestMarginOfVictorySingleWeek, weeklyAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Win), x => x.ScoreMargin, true),
                ToWeeklyRecord(RecordType.LowestMarginOfVictorySinglePlayoffWeek, weeklyPlayoffAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Win), x => x.ScoreMargin, true),
                ToWeeklyRecord(RecordType.HighestScoringLossSingleWeek, weeklyAggregationData.Where(x => x.MatchupOutcomeId == MatchupOutcomeId.Loss), x => x.Score),
            ];

            List<PlayerRecord> playerRecords =
            [
                ToPlayerRecord(RecordType.MostPointsScoredSinglePlayer, playerAggregationData.Where(x => !x.IsBench()), x => x.PointsScored),
                ToPlayerRecord(RecordType.MostPointsScoredSingleNonQBPlayer, playerAggregationData.Where(x => x.IsNotQBOrBench()), x => x.PointsScored),

                ToPlayerRecord(RecordType.LeastPointsScoredSinglePlayer, playerAggregationData.Where(x => !x.IsBench()), x => x.PointsScored, true),
                ToPlayerRecord(RecordType.LeastPointsScoredSingleNonDefensePlayer, playerAggregationData.Where(x => x.IsNotDSTOrBench()), x => x.PointsScored, true),
            ];

            return new LeagueRecordSummary(leagueRecords, seasonRecords, weeklyRecords, playerRecords);
        }

        private static LeagueRecord ToLeagueRecord(
            RecordType type,
            IEnumerable<LeagueMemberAggregatedStats> allTimeStats,
            Func<LeagueMemberAggregatedStats, decimal> valueSelector,
            bool isMinRecord = false)
        {
            LeagueMemberAggregatedStats stat = isMinRecord ? 
                allTimeStats.MinBy(valueSelector)! : 
                allTimeStats.MaxBy(valueSelector)!;
            
            return new LeagueRecord(
                stat.Member, 
                type, 
                valueSelector(stat)
            );
        }

        private static SeasonalRecord ToSeasonalRecord(
            RecordType type,
            IEnumerable<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason,
            Func<LeagueSeasonMemberAggregatedStats, decimal> valueSelector,
            bool isMinRecord = false)
        {
            LeagueSeasonMemberAggregatedStats stat = isMinRecord ? 
                statsByMemberAndSeason.MinBy(valueSelector)! : 
                statsByMemberAndSeason.MaxBy(valueSelector)!;

            return new SeasonalRecord(
                stat.Member, 
                type,
                stat.Year, 
                valueSelector(stat)
            );
        }

        private static WeeklyRecord ToWeeklyRecord(
            RecordType type,
            IEnumerable<WeeklyAggregationData> weeklyAggregationData,
            Func<WeeklyAggregationData, decimal> valueSelector,
            bool isMinRecord = false)
        {
            WeeklyAggregationData stat = isMinRecord ?
                weeklyAggregationData.MinBy(valueSelector)! :
                weeklyAggregationData.MaxBy(valueSelector)!;
            
            return new WeeklyRecord(
                stat.Member, 
                type,
                stat.Year, 
                stat.Week, 
                valueSelector(stat)
            );
        }

        private static PlayerRecord ToPlayerRecord(
            RecordType type,
            IEnumerable<PlayerAggregationData> playerAggregationData,
            Func<PlayerAggregationData, decimal> valueSelector,
            bool isMinRecord = false)
        {
            PlayerAggregationData stat = isMinRecord ?
                playerAggregationData.MinBy(valueSelector)! :
                playerAggregationData.MaxBy(valueSelector)!;

            return new PlayerRecord(
                stat.Member,
                type,
                stat.Player, 
                stat.Year, 
                stat.Week, 
                valueSelector(stat)
            );
        }
    }
}
