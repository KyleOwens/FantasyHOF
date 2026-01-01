using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.EntityFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mappers
{
    public interface IRecordCalculator
    {
        public LeagueRecordSummary? CalculateLeagueRecords(League league);
    }

    public class RecordCalculator() : IRecordCalculator
    {
        private const int BlowoutThreshold = 50;
        private const int NarrowThreshold = 3;
        private const int OutstandingPerformanceThreshold = 200;
        private const int PoorPerformanceThreshold = 100;

        public LeagueRecordSummary? CalculateLeagueRecords(League league)
        {
            IEnumerable<AggregatedMemberLeagueStats> aggregatedMemberLeagueStats = AggregateMemberLeagueStats(league);

            if (aggregatedMemberLeagueStats.Count() == 0) return null;

            var summary = CreateInitialLeagueRecordSummary(aggregatedMemberLeagueStats);

            foreach (var stat in aggregatedMemberLeagueStats.Skip(1))
            {
                // Good (max)
                UpdateMax(summary.MostPointsLeagueHistory, stat, s => s.MatchupStats.PointsFor);
                UpdateMax(summary.MostAveragePointsPerWeekLeagueHistory, stat, s => s.MatchupStats.PointsForAverage);
                UpdateMin(summary.LeastPointsAllowedLeagueHistory, stat, s => s.MatchupStats.PointsAgainst);
                UpdateMin(summary.LeastAveragePointsAllowedPerWeekLeagueHistory, stat, s => s.MatchupStats.PointsAgainstAverage);
                UpdateMax(summary.MostWinsLeagueHistory, stat, s => s.MatchupStats.Wins);
                UpdateMin(summary.LeastLossesLeagueHistory, stat, s => s.MatchupStats.Losses);
                UpdateMax(summary.HighestWinPercentageLeagueHistory, stat, s => s.MatchupStats.WinPercentage);
                UpdateMax(summary.MostTopWeeklyScoresLeagueHistory, stat, s => s.MatchupStats.TopWeeks);
                UpdateMax(summary.HighestPercentageTopWeeklyScoresLeagueHisotry, stat, s => s.MatchupStats.TopWeekPercentage);
                UpdateMax(summary.MostBlowoutWinsLeagueHistory, stat, s => s.MatchupStats.BlowoutWins);
                UpdateMax(summary.MostNarrowWinsLeagueHistory, stat, s => s.MatchupStats.NarrowWins);
                UpdateMax(summary.MostChampionshipsLeagueHistory, stat, s => s.RecordStats.Championships);
                UpdateMax(summary.HighestChampionshipPercentageLeagueHistory, stat, s => s.RecordStats.ChampionshipPercentage);
                UpdateMax(summary.MostSeasonsWinningRecordLeagueHistory, stat, s => s.RecordStats.WinningSeasons);
                UpdateMax(summary.HighestWinningRecordPercentageLeagueHistory, stat, s => s.RecordStats.WinningSeasonPercentage);
                UpdateMax(summary.MostOutstandingPerformancesLeagueHistory, stat, s => s.MatchupStats.OutstandingPerformances);

                // Bad (max of bad, min of good)
                UpdateMin(summary.LeastPointsLeagueHistory, stat, s => s.MatchupStats.PointsFor);
                UpdateMin(summary.LeastAveragePointsPerWeekLeagueHistory, stat, s => s.MatchupStats.PointsForAverage);
                UpdateMax(summary.MostPointsAllowedLeagueHistory, stat, s => s.MatchupStats.PointsAgainst);
                UpdateMax(summary.MostAveragePointsAllowedPerWeekLeagueHistory, stat, s => s.MatchupStats.PointsAgainstAverage);
                UpdateMin(summary.LeastWinsLeagueHistory, stat, s => s.MatchupStats.Wins);
                UpdateMax(summary.MostLossesLeagueHistory, stat, s => s.MatchupStats.Losses);
                UpdateMin(summary.LowestWinPercentageLeagueHistory, stat, s => s.MatchupStats.WinPercentage);
                UpdateMax(summary.MostLowestWeeklyScoresLeagueHistory, stat, s => s.MatchupStats.LowestWeeks);
                UpdateMax(summary.HighestPercentageLowestWeeklyScoresLeagueHisotry, stat, s => s.MatchupStats.LowestWeekPercentage);
                UpdateMax(summary.MostBlowoutLossesLeagueHistory, stat, s => s.MatchupStats.BlowoutLosses);
                UpdateMax(summary.MostNarrowLossesLeagueHistory, stat, s => s.MatchupStats.NarrowLosses);
                UpdateMax(summary.MostLastPlacesLeagueHistory, stat, s => s.RecordStats.LastPlaces);
                UpdateMax(summary.HighestLastPlacePercentageLeagueHistory, stat, s => s.RecordStats.LastPlacePercentage);
                UpdateMax(summary.MostSeasonsLosingRecordLeagueHistory, stat, s => s.RecordStats.LosingSeasons);
                UpdateMax(summary.HighestLosingRecordPercentageLeagueHistory, stat, s => s.RecordStats.LosingSeasonPercentage);
                UpdateMax(summary.MostPoorPerformancesLeagueHistory, stat, s => s.MatchupStats.PoorPerformances);
            }

            return summary;
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


        private LeagueRecordSummary CreateInitialLeagueRecordSummary(IEnumerable<AggregatedMemberLeagueStats> aggregatedStats)
        {
            var first = aggregatedStats.First();

            // Initialize summary with first member
            return new LeagueRecordSummary
            {
                // Good
                MostPointsLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsFor),
                MostAveragePointsPerWeekLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsForAverage),
                LeastPointsAllowedLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsAgainst),
                LeastAveragePointsAllowedPerWeekLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsAgainstAverage),
                MostWinsLeagueHistory = ToRecord(first, s => s.MatchupStats.Wins),
                LeastLossesLeagueHistory = ToRecord(first, s => s.MatchupStats.Losses),
                HighestWinPercentageLeagueHistory = ToRecord(first, s => s.MatchupStats.WinPercentage),
                MostTopWeeklyScoresLeagueHistory = ToRecord(first, s => s.MatchupStats.TopWeeks),
                HighestPercentageTopWeeklyScoresLeagueHisotry = ToRecord(first, s => s.MatchupStats.TopWeekPercentage),
                MostBlowoutWinsLeagueHistory = ToRecord(first, s => s.MatchupStats.BlowoutWins),
                MostNarrowWinsLeagueHistory = ToRecord(first, s => s.MatchupStats.NarrowWins),
                MostChampionshipsLeagueHistory = ToRecord(first, s => s.RecordStats.Championships),
                HighestChampionshipPercentageLeagueHistory = ToRecord(first, s => s.RecordStats.ChampionshipPercentage),
                MostSeasonsWinningRecordLeagueHistory = ToRecord(first, s => s.RecordStats.WinningSeasons),
                HighestWinningRecordPercentageLeagueHistory = ToRecord(first, s => s.RecordStats.WinningSeasonPercentage),
                MostOutstandingPerformancesLeagueHistory = ToRecord(first, s => s.MatchupStats.OutstandingPerformances),

                // Bad
                LeastPointsLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsFor),
                LeastAveragePointsPerWeekLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsForAverage),
                MostPointsAllowedLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsAgainst),
                MostAveragePointsAllowedPerWeekLeagueHistory = ToRecord(first, s => s.MatchupStats.PointsAgainstAverage),
                LeastWinsLeagueHistory = ToRecord(first, s => s.MatchupStats.Wins),
                MostLossesLeagueHistory = ToRecord(first, s => s.MatchupStats.Losses),
                LowestWinPercentageLeagueHistory = ToRecord(first, s => s.MatchupStats.WinPercentage),
                MostLowestWeeklyScoresLeagueHistory = ToRecord(first, s => s.MatchupStats.LowestWeeks),
                HighestPercentageLowestWeeklyScoresLeagueHisotry = ToRecord(first, s => s.MatchupStats.LowestWeekPercentage),
                MostBlowoutLossesLeagueHistory = ToRecord(first, s => s.MatchupStats.BlowoutLosses),
                MostNarrowLossesLeagueHistory = ToRecord(first, s => s.MatchupStats.NarrowLosses),
                MostLastPlacesLeagueHistory = ToRecord(first, s => s.RecordStats.LastPlaces),
                HighestLastPlacePercentageLeagueHistory = ToRecord(first, s => s.RecordStats.LastPlacePercentage),
                MostSeasonsLosingRecordLeagueHistory = ToRecord(first, s => s.RecordStats.LosingSeasons),
                HighestLosingRecordPercentageLeagueHistory = ToRecord(first, s => s.RecordStats.LosingSeasonPercentage),
                MostPoorPerformancesLeagueHistory = ToRecord(first, s => s.MatchupStats.PoorPerformances)
            };
        }

        private LeagueValueRecord ToRecord(AggregatedMemberLeagueStats stat, Func<AggregatedMemberLeagueStats, decimal> selector)
            => new(stat.Member, selector(stat));

        private void UpdateMax(
            LeagueValueRecord current,
            AggregatedMemberLeagueStats candidate,
            Func<AggregatedMemberLeagueStats, decimal> selector)
        {
            var candidateValue = selector(candidate);
            if (candidateValue > current.Value)
            {
                current.UpdateRecord(candidate.Member, candidateValue);
            }
        }

        private void UpdateMin(
            LeagueValueRecord current,
            AggregatedMemberLeagueStats candidate,
            Func<AggregatedMemberLeagueStats, decimal> selector)
        {
            var candidateValue = selector(candidate);
            if (candidateValue < current.Value)
            {
                current.UpdateRecord(candidate.Member, candidateValue);
            }
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
