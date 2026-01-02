using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class LeagueMemberAggregateStats
    {
        public int Id { get; private set; }
        public int LeagueId { get; private set; }
        public int MemberId { get; private set; }

        // Season-level stats
        public int TotalSeasons { get; init; }
        public int Championships { get; init; }
        public int LastPlaces { get; init; }
        public int WinningSeasons { get; init; }
        public int LosingSeasons { get; init; }

        // Matchup-level stats
        public int TotalMatchups { get; init; }
        public decimal TotalPointsFor { get; init; }
        public decimal TotalPointsAgainst { get; init; }
        public int TotalWins { get; init; }
        public int TotalLosses { get; init; }
        public int TopWeeks { get; init; }
        public int LowestWeeks { get; init; }
        public int BlowoutWins { get; init; }
        public int BlowoutLosses { get; init; }
        public int NarrowWins { get; init; }
        public int NarrowLosses { get; init; }
        public int OutstandingPerformances { get; init; }
        public int PoorPerformances { get; init; }

        // Calculated season-level stats
        public decimal ChampionshipPercentage => TotalSeasons > 0 ? (decimal)Championships / TotalSeasons : 0;
        public decimal LastPlacePercentage => TotalSeasons > 0 ? (decimal)LastPlaces / TotalSeasons : 0;
        public decimal WinningSeasonPercentage => TotalSeasons > 0 ? (decimal)WinningSeasons / TotalSeasons : 0;
        public decimal LosingSeasonPercentage => TotalSeasons > 0 ? (decimal)LosingSeasons / TotalSeasons : 0;

        // Calculated matchup-level stats
        public decimal PointsForAverage => TotalMatchups > 0 ? TotalPointsFor / TotalMatchups : 0;
        public decimal PointsAgainstAverage => TotalMatchups > 0 ? TotalPointsAgainst / TotalMatchups : 0;
        public decimal WinPercentage => TotalMatchups > 0 ? (decimal)TotalWins / TotalMatchups : 0;
        public decimal TopWeekPercentage => TotalMatchups > 0 ? (decimal)TopWeeks / TotalMatchups : 0;
        public decimal LowestWeekPercentage => TotalMatchups > 0 ? (decimal)LowestWeeks / TotalMatchups : 0;
        
        // Navigation
        public League League { get; init; } = null!;
        public FantasyMember Member { get; init; } = null!;
    }
}
