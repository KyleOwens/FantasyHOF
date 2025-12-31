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
        private interface IHasMember { FantasyMember Member { get; } }
        
        private record AggregatedMemberLeagueStats(
            FantasyMember Member,
            decimal TotalPointsFor,
            decimal TotalPointsForAverage,
            decimal TotalPointsAgainst) : IHasMember
        {

        }

        public LeagueRecordSummary CalculateLeagueRecords(League league)
        {
            IEnumerable<AggregatedMemberLeagueStats> aggregatedMemberLeagueStats = AggregateMemberLeagueStats(league);

            return new LeagueRecordSummary
            {
                MostPointsLeagueHistory = ExtractLeagueRecord(
                    aggregatedMemberLeagueStats.OrderByDescending(x => x.TotalPointsFor).First(), 
                    stats => stats.TotalPointsFor),

                MostAveragePointsPerWeekLeagueHistory = ExtractLeagueRecord(
                    aggregatedMemberLeagueStats.OrderByDescending(x => x.TotalPointsForAverage).First(),
                    stats => stats.TotalPointsForAverage)
            };
        }

        private IEnumerable<AggregatedMemberLeagueStats> AggregateMemberLeagueStats(League league)
        {
            return league.Seasons
                .SelectMany(season => season.Members)
                .GroupBy(seasonMember => seasonMember.Member.Id)
                .Select(group =>
                {
                     IEnumerable<TeamMatchup> allMatchups = group
                         .SelectMany(member => member.Teams)
                         .SelectMany(memberTeam => memberTeam.Team.Matchups);

                     decimal totalPointsFor = allMatchups.Sum(matchup => matchup.OwnerMatchupDetails.Score);
                     decimal totalPointsAgainst = allMatchups.Sum(matchup => matchup.OpponentMatchupDetails?.Score ?? 0);

                     decimal totalWeeks = group
                         .SelectMany(member => member.Teams)
                         .Select(memberTeam => memberTeam.Team.Matchups)
                         .Sum(x => x.Count);

                     return new AggregatedMemberLeagueStats(
                         group.First().Member,
                         totalPointsFor,
                         totalPointsFor/totalWeeks,
                         totalPointsAgainst);
                });
        }

        private LeagueValueRecord ExtractLeagueRecord<T>(
            T source,
            Func<T, decimal> valueSelector) where T : IHasMember
        {
            return new LeagueValueRecord(source.Member, valueSelector(source));
        }
    }
}
