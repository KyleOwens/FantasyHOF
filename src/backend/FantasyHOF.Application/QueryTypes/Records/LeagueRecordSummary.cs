using FantasyHOF.Application.Enums;
using FantasyHOF.Application.Registries;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.Domain.Types.Views;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            // This could be made much more efficient by iterating over each list just one time. For now, leave for simplicity
            List<LeagueRecord> leagueRecords =
            [
                ToLeagueRecord(RecordTypeId.MostChampionshipsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestChampionshipPercentageLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostWinsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestWinPercentageLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostSeasonsWinningRecordLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestWinningRecordPercentageLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostPointsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostAveragePointsPerWeekLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostOutstandingPerformancesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostBlowoutWinsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostNarrowWinsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostTopWeeklyScoresLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestPercentageTopWeeklyScoresLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LeastLossesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LeastPointsAllowedLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LeastAveragePointsAllowedPerWeekLeagueHistory, allTimeStatsByMember),

                ToLeagueRecord(RecordTypeId.MostLastPlacesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestLastPlacePercentageLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostLossesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LowestWinPercentageLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostSeasonsLosingRecordLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestLosingRecordPercentageLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostPointsAllowedLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostAveragePointsAllowedPerWeekLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostPoorPerformancesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostBlowoutLossesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostNarrowLossesLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.MostLowestWeeklyScoresLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.HighestPercentageLowestWeeklyScoresLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LeastWinsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LeastPointsLeagueHistory, allTimeStatsByMember),
                ToLeagueRecord(RecordTypeId.LeastAveragePointsPerWeekLeagueHistory, allTimeStatsByMember),
            ];

            List<SeasonalRecord> seasonRecords =
            [
                ToSeasonalRecord(RecordTypeId.MostPointsSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostPointsPerWeekSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.LeastPointsAllowedSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.LeastPointsAllowedPerWeekSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostWinsSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostOutstandingPerformancesSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostBlowoutWinsSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostNarrowWinsSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostHighestScoringWeeksSingleSeason, statsByMemberAndSeason),

                ToSeasonalRecord(RecordTypeId.LeastPointsSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.LeastPointsPerWeekSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostPointsAllowedSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostPointsAllowedPerWeekSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostLossesSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostPoorPerformancesSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostBlowoutLossesSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostNarrowLossesSingleSeason, statsByMemberAndSeason),
                ToSeasonalRecord(RecordTypeId.MostLowestScoringWeeksSingleSeason, statsByMemberAndSeason),
            ];

            List<WeeklyRecord> weeklyRecords =
            [
                ToWeeklyRecord(RecordTypeId.MostPointsSingleWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.MostPointsSinglePlayoffWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.LargestMarginOfVictorySingleWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.LargestMarginOfVictorySinglePlayoffWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.LowestScoringWinSingleWeek, weeklyAggregationData),

                ToWeeklyRecord(RecordTypeId.LeastPointsSingleWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.LeastPointsSinglePlayoffWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.LowestMarginOfVictorySingleWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.LowestMarginOfVictorySinglePlayoffWeek, weeklyAggregationData),
                ToWeeklyRecord(RecordTypeId.HighestScoringLossSingleWeek, weeklyAggregationData),
            ];

            List<PlayerRecord> playerRecords =
            [
                ToPlayerRecord(RecordTypeId.MostPointsScoredSinglePlayer, playerAggregationData),
                ToPlayerRecord(RecordTypeId.MostPointsScoredSingleNonQBPlayer, playerAggregationData),

                ToPlayerRecord(RecordTypeId.LeastPointsScoredSinglePlayer, playerAggregationData),
                ToPlayerRecord(RecordTypeId.LeastPointsScoredSingleNonDefensePlayer, playerAggregationData),
            ];

            return new LeagueRecordSummary(leagueRecords, seasonRecords, weeklyRecords, playerRecords);
        }

        private static LeagueRecord ToLeagueRecord(
            RecordTypeId recordType,
            IEnumerable<LeagueMemberAggregatedStats> allTimeStats)
        {
            RecordMetricProjector<LeagueMemberAggregatedStats> projector = new(recordType);

            LeagueMemberAggregatedStats winnerStats = projector.ExtractWinnerFromList(allTimeStats);

            return new LeagueRecord(
                winnerStats.MemberDetails.Member, 
                recordType,
                projector.GetMetric(winnerStats)
            );
        }

        private static SeasonalRecord ToSeasonalRecord(
            RecordTypeId recordType,
            IEnumerable<LeagueSeasonMemberAggregatedStats> statsByMemberAndSeason)
        {
            RecordMetricProjector<LeagueSeasonMemberAggregatedStats> projector = new(recordType);

            LeagueSeasonMemberAggregatedStats winnerStats = projector.ExtractWinnerFromList(statsByMemberAndSeason);

            return new SeasonalRecord(
                winnerStats.MemberDetails.Member, 
                recordType,
                winnerStats.Year, 
                projector.GetMetric(winnerStats)
            );
        }

        private static WeeklyRecord ToWeeklyRecord(
            RecordTypeId recordType,
            IEnumerable<WeeklyAggregationData> weeklyAggregationData)
        {
            RecordMetricProjector<WeeklyAggregationData> projector = new(recordType);

            WeeklyAggregationData winnerStats = projector.ExtractWinnerFromList(weeklyAggregationData);

            return new WeeklyRecord(
                winnerStats.MemberDetails.Member, 
                recordType,
                winnerStats.Year,
                winnerStats.Week, 
                projector.GetMetric(winnerStats)
            );
        }

        private static PlayerRecord ToPlayerRecord(
            RecordTypeId recordType,
            IEnumerable<PlayerAggregationData> playerAggregationData)
        {
            RecordMetricProjector<PlayerAggregationData> projector = new(recordType);

            PlayerAggregationData winnerStats = projector.ExtractWinnerFromList(playerAggregationData);

            return new PlayerRecord(
                winnerStats.MemberDetails.Member,
                recordType,
                winnerStats.Player,
                winnerStats.Year,
                winnerStats.Week, 
                projector.GetMetric(winnerStats)
            );
        }
    }
}
