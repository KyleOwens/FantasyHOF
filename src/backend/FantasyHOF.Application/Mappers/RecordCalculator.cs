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
        public LeagueRecordSummary CalculateLeagueRecords(League league)
        {
            var groupedMembers = league.Seasons
                .SelectMany(season => season.Members)
                .GroupBy(seasonMember => seasonMember.Member.Id);

            var aggregatedSeasonStats = AggregateLeagueRecordStats(league);

            return new LeagueRecordSummary
            {
                MostPointsLeagueHistory = CalculateMostPointsLeagueHistory(groupedMembers),
                MostAveragePointsPerWeekLeagueHistory = CalcualteMostAveragePointsPerWeekLeagueHistory(groupedMembers)
            };
        }

        private object AggregateLeagueRecordStats(League league)
        {
            var groupedMembers = league.Seasons
                .SelectMany(season => season.Members)
                .GroupBy(seasonMember => seasonMember.Member.Id)
                .Select(group =>
                 {
                     IEnumerable<TeamMatchup> allMatchups = group
                         .SelectMany(member => member.Teams)
                         .SelectMany(memberTeam => memberTeam.Team.Matchups);
                         

                     decimal totalPointsFor = allMatchups.Sum(matchup => matchup.Score);
                     decimal totalPointsAgainst = allMatchups.Sum(matchup => matchup.Opponent.Matchups.Single(x => x.Week == )


                     decimal totalWeeks = group
                         .SelectMany(member => member.Teams)
                         .Select(memberTeam => memberTeam.Team.Matchups)
                         .Sum(x => x.Count);

                     return new
                     {
                         group.First().Member,
                         TotalPointsFor = totalPointsFor,
                         AveragePointsFor = totalPointsFor / totalWeeks
                     };
                 })
                .OrderByDescending(x => x.TotalPoints)
                .First();
        }

        private LeagueValueRecord CalculateMostPointsLeagueHistory(Leag)
        {
            

            var record = groupedMembers
                

            return new LeagueValueRecord(record.Member, record.TotalPoints);
        }

        private LeagueValueRecord CalcualteMostAveragePointsPerWeekLeagueHistory(
            IEnumerable<IGrouping<int, LeagueSeasonMember>> groupedMembers)
        {
            var record = groupedMembers
                .Select(group =>
                {
                    decimal totalPoints = group
                        .SelectMany(member => member.Teams)
                        .SelectMany(memberTeam => memberTeam.Team.Matchups)
                        .Sum(matchup => matchup.Score);

                    decimal totalWeeks = group
                        .SelectMany(member => member.Teams)
                        .Select(memberTeam => memberTeam.Team.Matchups)
                        .Sum(x => x.Count);

                    return new
                    {
                        group.First().Member,
                        AverageWeeklyScore = totalPoints / totalWeeks
                    };
                })
                .OrderByDescending(x => x.AverageWeeklyScore)
                .First();

            return new LeagueValueRecord(record.Member, record.AverageWeeklyScore);
        }
    }
}
