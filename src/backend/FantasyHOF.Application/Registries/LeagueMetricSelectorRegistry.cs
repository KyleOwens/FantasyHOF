using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Registries
{
    public static class LeagueMetricSelectorRegistry
    {
        public static readonly IReadOnlyDictionary<RecordMetricId, Expression<Func<LeagueMemberAggregatedStats, decimal>>> Selectors =
            new Dictionary<RecordMetricId, Expression<Func<LeagueMemberAggregatedStats, decimal>>>
            {
                [RecordMetricId.Championships] = stats => stats.Championships,
                [RecordMetricId.ChampionshipPercentage] = stats => stats.ChampionshipPercentage,
                [RecordMetricId.Wins] = stats => stats.Wins,
                [RecordMetricId.WinPercentage] = stats => stats.WinPercentage,
                [RecordMetricId.WinningSeasons] = stats => stats.WinningSeasons,
                [RecordMetricId.WinningSeasonPercentage] = stats => stats.WinningSeasonPercentage,
                [RecordMetricId.PointsFor] = stats => stats.PointsFor,
                [RecordMetricId.PointsForAverage] = stats => stats.PointsForAverage,
                [RecordMetricId.OutstandingPerformances] = stats => stats.OutstandingPerformances,
                [RecordMetricId.BlowoutWins] = stats => stats.BlowoutWins,
                [RecordMetricId.NarrowWins] = stats => stats.NarrowWins,
                [RecordMetricId.TopWeeks] = stats => stats.TopWeeks,
                [RecordMetricId.TopWeekPercentage] = stats => stats.TopWeekPercentage,
                [RecordMetricId.Losses] = stats => stats.Losses,
                [RecordMetricId.PointsAgainst] = stats => stats.PointsAgainst,
                [RecordMetricId.PointsAgainstAverage] = stats => stats.PointsAgainstAverage,
                [RecordMetricId.LastPlaces] = stats => stats.LastPlaces,
                [RecordMetricId.LastPlacePercentage] = stats => stats.LastPlacePercentage,
                [RecordMetricId.LosingSeasons] = stats => stats.LosingSeasons,
                [RecordMetricId.LosingSeasonPercentage] = stats => stats.LosingSeasonPercentage,
                [RecordMetricId.PoorPerformances] = stats => stats.PoorPerformances,
                [RecordMetricId.BlowoutLosses] = stats => stats.BlowoutLosses,
                [RecordMetricId.NarrowLosses] = stats => stats.NarrowLosses,
                [RecordMetricId.BottomWeeks] = stats => stats.BottomWeeks,
                [RecordMetricId.BottomWeekPercentage] = stats => stats.BottomWeekPercentage,
                [RecordMetricId.Seasons] = stats => stats.TotalSeasons,
                [RecordMetricId.Weeks] = stats => stats.TotalMatchups
            };
    }
}
