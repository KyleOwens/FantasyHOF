using FantasyHOF.Domain.ComplexIds;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.Domain.Types.Records;
using FantasyHOF.EntityFramework;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mappers
{
    public interface IStatAggregator
    {
        public void AggregateMemberStats(League league);
    }

    public class StatAggregator : IStatAggregator
    {
        private const int BlowoutThreshold = 50;
        private const int NarrowThreshold = 3;
        private const int OutstandingPerformanceThreshold = 200;
        private const int PoorPerformanceThreshold = 100;

        public void AggregateMemberStats(League league)
        {
            LeagueAggregationContext aggregationContext = BuildLeagueAggregationContext(league);

            return; 
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
                    .GroupBy(matchup => (matchup.Week, matchup.Year))
                    .ToDictionary(group => group.Key, group => group.Max(matchup => matchup.OwnerMatchupDetails.Score)),

                MinScoreByWeekLookup = allLeagueMatchups
                    .GroupBy(matchup => (matchup.Week, matchup.Year))
                    .ToDictionary(group => group.Key, group => group.Min(matchup => matchup.OwnerMatchupDetails.Score)),

                LastPlacePositionBySeasonLookup = league.Seasons.ToDictionary(
                    season => season.Year,
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
                    if (true) lastPlaces++;

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



        private void CalculateSeasonMemberMatchupStats(LeagueSeason season, LeagueSeasonMember seasonMember, LeagueAggregationContext aggregationContext)
        {
            IEnumerable<TeamMatchup> seasonMemberMatchups = seasonMember.Teams
                .SelectMany(seasonMember => seasonMember.Team.Matchups);

            int year = seasonMemberMatchups.FirstOrDefault()?.Year ?? 0;
            int seasonRank = seasonMember.Teams.Max(seasonMemberTeam => seasonMemberTeam.Team.SeasonRank);
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

            int mostPointsSingleWeek = 0;
            int mostPointsSinglePlayoffWeek = 0;
            int largestMarginOfVictory = 0;

            

            foreach (TeamMatchup matchup in seasonMemberMatchups)
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

            return;
        }

        private static bool IsTopWeek(TeamMatchup matchup, LeagueAggregationContext context)
        {
            var key = (matchup.Week, matchup.Year);
            return context.MaxScoreByWeekLookup.TryGetValue(key, out var max) && matchup.OwnerMatchupDetails.Score == max;
        }

        private static bool IsLowestWeek(TeamMatchup matchup, LeagueAggregationContext context)
        {
            var key = (matchup.Week, matchup.Year);
            return context.MinScoreByWeekLookup.TryGetValue(key, out var min) && matchup.OwnerMatchupDetails.Score == min;
        }

        private static bool IsLastPlaceFinish(int year, int seasonRank, LeagueAggregationContext aggregationContext)
        {
            if (!aggregationContext.LastPlacePositionBySeasonLookup.TryGetValue(year, out int lastPlacePosition))
                return false;

            return seasonRank == lastPlacePosition;
        }

        //private LeagueSeasonMemberAggregateStats MapLeagueMemberAggregateStats(League league, FantasyMember member, AggregatedMemberRecordStats recordStats, AggregatedMemberMatchupStats matchupStats)
        //{
        //    return new LeagueSeasonMemberAggregateStats
        //    {
        //        League = league,
        //        Member = member,

        //        TotalSeasons = recordStats.TotalSeasons,
        //        Championships = recordStats.Championships,
        //        LastPlaces = recordStats.LastPlaces,
        //        WinningSeasons = recordStats.WinningSeasons,
        //        LosingSeasons = recordStats.LosingSeasons,

        //        MatchupCount = matchupStats.MatchupCount,
        //        PointsFor = matchupStats.PointsFor,
        //        PointsAgainst = matchupStats.PointsAgainst,
        //        Wins = matchupStats.Wins,
        //        Losses = matchupStats.Losses,
        //        TopWeeks = matchupStats.TopWeeks,
        //        LowestWeeks = matchupStats.LowestWeeks,
        //        BlowoutWins = matchupStats.BlowoutWins,
        //        BlowoutLosses = matchupStats.BlowoutLosses,
        //        NarrowWins = matchupStats.NarrowWins,
        //        NarrowLosses = matchupStats.NarrowLosses,
        //        OutstandingPerformances = matchupStats.OutstandingPerformances,
        //        PoorPerformances = matchupStats.PoorPerformances,
        //    };
        //}

        private sealed class LeagueAggregationContext
        {
            public required Dictionary<(int week, int seasonId), decimal> MaxScoreByWeekLookup { get; init; }
            public required Dictionary<(int week, int seasonId), decimal> MinScoreByWeekLookup { get; init; }
            public required Dictionary<int, int> LastPlacePositionBySeasonLookup { get; init; }
        }

        private sealed record AggregatedMemberRecordStats(
            int TotalSeasons,
            int Championships,
            int LastPlaces,
            int WinningSeasons,
            int LosingSeasons);

        private sealed record AggregatedSeasonMemberMatchupStats(
            int Year,
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
            int PoorPerformances);
    }
}
