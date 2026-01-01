using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mappers
{
    public interface IRecordCalculator
    {
        public LeagueRecordSummary CalculateLeagueRecords(League league);
    }

    public class RecordCalculator() : IRecordCalculator
    {
        private const int BlowoutThreshold = 50;
        private const int NarrowThreshold = 3;
        private const int OutstandingPerformanceThreshold = 200;
        private const int PoorPerformanceThreshold = 100;

        public LeagueRecordSummary CalculateLeagueRecords(League league)
        {
            IEnumerable<AggregatedMemberLeagueStats> aggregatedMemberLeagueStats = AggregateMemberLeagueStats(league);

            return new LeagueRecordSummary
            {
                // Good league
                MostPointsLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsFor),

                MostAveragePointsPerWeekLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsForAverage),

                LeastPointsAllowedLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsAgainst),

                LeastAveragePointsAllowedPerWeekLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsAgainstAverage),

                MostWinsLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.Wins),

                LeastLossesLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.Losses),

                HighestWinPercentageLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.WinPercentage),

                MostTopWeeklyScoresLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.TopWeeks),

                HighestPercentageTopWeeklyScoresLeagueHisotry = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.TopWeekPercentage),

                MostBlowoutWinsLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.BlowoutWins),

                MostNarrowWinsLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.NarrowWins),

                MostChampionshipsLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.Championships),

                HighestChampionshipPercentageLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.ChampionshipPercentage),

                MostSeasonsWinningRecordLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.WinningSeasons),

                HighestWinningRecordPercentageLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.WinningSeasonPercentage),

                MostOutstandingPerformancesLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.OutstandingPerformances),

                // Bad league
                LeastPointsLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsFor),

                LeastAveragePointsPerWeekLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsForAverage),

                MostPointsAllowedLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsAgainst),

                MostAveragePointsAllowedPerWeekLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PointsAgainstAverage),

                LeastWinsLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.Wins),

                MostLossesLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.Losses),

                LowestWinPercentageLeagueHistory = ExtractMinLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.WinPercentage),

                MostLowestWeeklyScoresLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.LowestWeeks),

                HighestPercentageLowestWeeklyScoresLeagueHisotry = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.LowestWeekPercentage),

                MostBlowoutLossesLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.BlowoutLosses),

                MostNarrowLossesLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.NarrowLosses),

                MostLastPlacesLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.LastPlaces),

                HighestLastPlacePercentageLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.LastPlacePercentage),

                MostSeasonsLosingRecordLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.LosingSeasons),

                HighestLosingRecordPercentageLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.RecordStats.LosingSeasonPercentage),

                MostPoorPerformancesLeagueHistory = ExtractMaxLeagueRecord(
                    aggregatedMemberLeagueStats, x => x.MatchupStats.PoorPerformances)
            };
        }

        private IEnumerable<AggregatedMemberLeagueStats> AggregateMemberLeagueStats(League league)
        {
            LeagueAggregationContext aggregationContext = BuildLeagueAggregationContext(league);

            return league.Seasons
                .SelectMany(season => season.Members)
                .GroupBy(seasonMember => seasonMember.Member.Id)
                .Select(group =>
                {
                    IEnumerable<LeagueSeasonMemberTeam> memberTeams = group
                        .SelectMany(member => member.Teams);

                    IEnumerable<TeamMatchup> memberMatchups = memberTeams
                        .SelectMany(memberTeam => memberTeam.Team.Matchups);

                    AggregatedMemberRecordStats recordStats = CalculateRecordStats(group, aggregationContext);
                    AggregatedMemberMatchupStats matchupStats = CalculateMatchupStats(memberMatchups, aggregationContext);

                    return new AggregatedMemberLeagueStats()
                    {
                        Member = group.First().Member,
                        RecordStats = recordStats,
                        MatchupStats = matchupStats
                    };
                });
        }

        private LeagueAggregationContext BuildLeagueAggregationContext(League league)
        {
            IEnumerable<TeamMatchup> allLeagueMatchups = league.Seasons
                .SelectMany(season => season.Members)
                .SelectMany(member => member.Teams)
                .SelectMany(memberTeam => memberTeam.Team.Matchups);

            return new LeagueAggregationContext
            {
                MaxScoreByWeekLookup = allLeagueMatchups
                    .GroupBy(matchup => (matchup.Week, matchup.OwnerMatchupDetails.Team.LeagueSeasonId))
                    .ToDictionary(group => group.Key, group => group.Max(matchup => matchup.OwnerMatchupDetails.Score)),

                MinScoreByWeekLookup = allLeagueMatchups
                    .GroupBy(matchup => (matchup.Week, matchup.OwnerMatchupDetails.Team.LeagueSeasonId))
                    .ToDictionary(group => group.Key, group => group.Min(matchup => matchup.OwnerMatchupDetails.Score)),

                LastPlacePositionBySeasonLookup = league.Seasons.ToDictionary(
                    season => season.Id,
                    season => season.Members.SelectMany(seasonMember => seasonMember.Teams).Max(memberTeam => memberTeam.Team.SeasonRank))
            };
        }

        private AggregatedMemberRecordStats CalculateRecordStats(IEnumerable<LeagueSeasonMember> memberSeasons, LeagueAggregationContext aggregationContext)
        {
            int championships = 0;
            int lastPlaces = 0;
            int winningSeasons = 0;
            int losingSeasons = 0;

            foreach (LeagueSeasonMember memberSeason in memberSeasons)
            {
                int seasonWins = 0;
                int seasonLosses = 0;
                
                foreach (LeagueSeasonMemberTeam memberTeam in memberSeason.Teams)
                {
                    Team team = memberTeam.Team;
                    
                    if (team.SeasonRank == 1) championships++;
                    if (IsLastPlaceFinish(team, aggregationContext)) lastPlaces++;

                    foreach (TeamMatchup matchup in team.Matchups)
                    {
                        if (matchup.OwnerMatchupDetails.MatchupOutcomeId == MatchupOutcomeId.Win) seasonWins++;
                        if (matchup.OwnerMatchupDetails.MatchupOutcomeId == MatchupOutcomeId.Loss) seasonLosses++;
                    }
                }

                if (seasonWins > seasonLosses) winningSeasons++;
                if (seasonLosses > seasonWins) losingSeasons++;
            }

            return new AggregatedMemberRecordStats(memberSeasons.Count(), championships, lastPlaces, winningSeasons, losingSeasons);
        }

        private bool IsLastPlaceFinish(Team team, LeagueAggregationContext aggregationContext)
        {
            if (!aggregationContext.LastPlacePositionBySeasonLookup.TryGetValue(team.LeagueSeasonId, out int lastPlacePosition))
                return false;

            return team.SeasonRank == lastPlacePosition;
        }

        private AggregatedMemberMatchupStats CalculateMatchupStats(IEnumerable<TeamMatchup> memberMatchups, LeagueAggregationContext aggregationContext)
        {
            decimal pointsFor = 0;
            decimal pointsAgainst = 0;
            int wins = 0;
            int losses = 0;
            int topWeeks = 0;
            int lowestWeeks = 0;
            int blowoutWins = 0;
            int blowoutLosses = 0;
            int narrowWins = 0;
            int narrowLosses = 0;
            int outstandingPerformances = 0;
            int poorPerformances = 0;

            foreach (TeamMatchup matchup in memberMatchups)
            {
                decimal score = matchup.OwnerMatchupDetails.Score;
                decimal margin = matchup.ScoreMargin;
                MatchupOutcomeId outcome = matchup.OwnerMatchupDetails.MatchupOutcomeId;

                pointsFor += score;
                pointsAgainst += matchup.OpponentMatchupDetails?.Score ?? 0;

                if (outcome == MatchupOutcomeId.Win) wins++;
                if (outcome == MatchupOutcomeId.Loss) losses++;
                if (IsTopWeek(matchup, aggregationContext)) topWeeks++;
                if (IsLowestWeek(matchup, aggregationContext)) lowestWeeks++;
                if (margin > BlowoutThreshold) blowoutWins++;
                if (margin < -BlowoutThreshold) blowoutLosses++;
                if (margin <= NarrowThreshold && outcome == MatchupOutcomeId.Win) narrowWins++;
                if (margin >= -NarrowThreshold && outcome == MatchupOutcomeId.Loss) narrowLosses++;
                if (score > OutstandingPerformanceThreshold) outstandingPerformances++;
                if (score < PoorPerformanceThreshold) poorPerformances++;
            }

            return new AggregatedMemberMatchupStats(memberMatchups.Count(), pointsFor, pointsAgainst, wins, losses, topWeeks, lowestWeeks, 
                blowoutWins, blowoutLosses, narrowWins, narrowLosses, outstandingPerformances, poorPerformances);
        }

        private bool IsTopWeek(TeamMatchup matchup, LeagueAggregationContext context)
        {
            var key = (matchup.Week, matchup.OwnerMatchupDetails.Team.LeagueSeasonId);
            return context.MaxScoreByWeekLookup.TryGetValue(key, out var max) && matchup.OwnerMatchupDetails.Score == max;
        }

        private bool IsLowestWeek(TeamMatchup matchup, LeagueAggregationContext context)
        {
            var key = (matchup.Week, matchup.OwnerMatchupDetails.Team.LeagueSeasonId);
            return context.MinScoreByWeekLookup.TryGetValue(key, out var min) && matchup.OwnerMatchupDetails.Score == min;
        }

        private LeagueValueRecord ExtractMaxLeagueRecord(
            IEnumerable<AggregatedMemberLeagueStats> aggregatedLeagueMemberStats,
            Func<AggregatedMemberLeagueStats, decimal> valueSelector)
        {
            AggregatedMemberLeagueStats stats = aggregatedLeagueMemberStats.OrderByDescending(valueSelector).First();
            return new LeagueValueRecord(stats.Member, valueSelector(stats));
        }

        private LeagueValueRecord ExtractMinLeagueRecord(
            IEnumerable<AggregatedMemberLeagueStats> aggregatedLeagueMemberStats,
            Func<AggregatedMemberLeagueStats, decimal> valueSelector)
        {
            AggregatedMemberLeagueStats stats = aggregatedLeagueMemberStats.OrderBy(valueSelector).First();
            return new LeagueValueRecord(stats.Member, valueSelector(stats));
        }

        private sealed class LeagueAggregationContext
        {
            public required Dictionary<(int week, int seasonId), decimal> MaxScoreByWeekLookup { get; init; }
            public required Dictionary<(int week, int seasonId), decimal> MinScoreByWeekLookup { get; init; }
            public required Dictionary<int, int> LastPlacePositionBySeasonLookup { get; init; }
        }

        private sealed class AggregatedMemberLeagueStats()
        {
            public required FantasyMember Member { get; init; }
            public required AggregatedMemberRecordStats RecordStats { get; init; }
            public required AggregatedMemberMatchupStats MatchupStats { get; init; }
        }

        private sealed record AggregatedMemberRecordStats(
            int TotalSeasons,
            int Championships,
            int LastPlaces,
            int WinningSeasons,
            int LosingSeasons)
        {
            public decimal ChampionshipPercentage => TotalSeasons > 0 ? (decimal)Championships / TotalSeasons : 0;
            public decimal LastPlacePercentage => TotalSeasons > 0 ? (decimal)LastPlaces / TotalSeasons : 0;
            public decimal WinningSeasonPercentage => TotalSeasons > 0 ? (decimal)WinningSeasons / TotalSeasons : 0;
            public decimal LosingSeasonPercentage => TotalSeasons > 0 ? (decimal)LosingSeasons / TotalSeasons : 0;
        }

        private sealed record AggregatedMemberMatchupStats(
            int MatchupCount,
            decimal PointsFor,
            decimal PointsAgainst,
            int Wins,
            int Losses,
            int TopWeeks,
            int LowestWeeks,
            int BlowoutWins,
            int BlowoutLosses,
            int NarrowWins,
            int NarrowLosses,
            int OutstandingPerformances,
            int PoorPerformances)
        {
            public decimal PointsForAverage => MatchupCount > 0 ? PointsFor / MatchupCount : 0;
            public decimal PointsAgainstAverage => MatchupCount > 0 ? PointsAgainst / MatchupCount : 0;
            public decimal WinPercentage => MatchupCount > 0 ? (decimal)Wins / MatchupCount : 0;
            public decimal TopWeekPercentage => MatchupCount > 0 ? (decimal)TopWeeks / MatchupCount : 0;
            public decimal LowestWeekPercentage => MatchupCount > 0 ? (decimal)LowestWeeks / MatchupCount : 0;
        }
    }
}
