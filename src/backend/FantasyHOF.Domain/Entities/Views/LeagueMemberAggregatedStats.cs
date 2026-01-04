using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Views
{
    public class LeagueMemberAggregatedStats
    {
        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }
        public int TotalSeasons { get; private set; }
        public int TotalMatchups { get; private set; }
        public decimal PointsFor { get; private set; }
        public decimal PointsAgainst { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
        public int TopWeeks { get; private set; }
        public int BottomWeeks { get; private set; }
        public int BlowoutWins { get; private set; }
        public int BlowoutLosses { get; private set; }
        public int NarrowWins { get; private set; }
        public int NarrowLosses { get; private set; }
        public int Championships { get; private set; }
        public int LastPlaces { get; private set; }
        public int WinningSeasons { get; private set; }
        public int LosingSeasons { get; private set; }
        public int OutstandingPerformances { get; private set; }
        public int PoorPerformances { get; private set; }

        public decimal PointsForAverage => TotalMatchups > 0 ? PointsFor / TotalMatchups : 0;
        public decimal PointsAgainstAverage => TotalMatchups > 0 ? PointsAgainst / TotalMatchups : 0;
        public decimal WinPercentage => TotalMatchups > 0 ? (decimal)Wins / TotalMatchups : 0;
        public decimal TopWeekPercentage => TotalMatchups > 0 ? (decimal)TopWeeks / TotalMatchups : 0;
        public decimal BottomWeekPercentage => TotalMatchups > 0 ? (decimal)BottomWeeks / TotalMatchups : 0;
        public decimal ChampionshipPercentage => TotalSeasons > 0 ? (decimal)Championships / TotalSeasons : 0;
        public decimal LastPlacePercentage => TotalSeasons > 0 ? (decimal)LastPlaces / TotalSeasons : 0;
        public decimal WinningSeasonPercentage => TotalSeasons > 0 ? (decimal)WinningSeasons / TotalSeasons : 0;
        public decimal LosingSeasonPercentage => TotalSeasons > 0 ? (decimal)LosingSeasons / TotalSeasons : 0;

        public FantasyMember Member { get; private set; } = null!;
    }
}
