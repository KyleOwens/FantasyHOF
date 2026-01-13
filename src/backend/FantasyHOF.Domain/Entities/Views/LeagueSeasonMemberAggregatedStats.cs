using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities.Views
{
    public class LeagueSeasonMemberAggregatedStats
    {
        public int MemberId { get; private set; }
        public int LeagueId { get; private set; }
        public int Year { get; private set; }
        public int TotalMatchups { get; private set; }
        public int SeasonRank { get; private set; }
        public decimal PointsFor { get; private set; }
        public decimal PointsForAverage { get; private set; }
        public decimal PointsAgainst { get; private set; }
        public decimal PointsAgainstAverage { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public decimal WinPercentage { get; private set; }
        public int TopWeeks { get; private set; }
        public decimal TopWeekPercentage{ get; private set; }
        public int BottomWeeks { get; private set; }
        public decimal BottomWeekPercentage { get; private set; }
        public int BlowoutWins { get; private set; }
        public int BlowoutLosses { get; private set; }
        public int NarrowWins { get; private set; }
        public int NarrowLosses { get; private set; }
        public int OutstandingPerformances { get; private set; }
        public int PoorPerformances { get; private set; }

        public LeagueMember MemberDetails { get; private set; } = null!;
    }
}
