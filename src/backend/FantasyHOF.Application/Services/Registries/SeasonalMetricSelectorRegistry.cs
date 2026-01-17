using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities.Views;
using System.Linq.Expressions;

namespace FantasyHOF.Application.Services.Registries
{
    public static class SeasonalMetricSelectorRegistry
    {
        public static readonly IReadOnlyDictionary<RecordMetricId, Expression<Func<LeagueSeasonMemberAggregatedStats, decimal>>> Selectors =
            new Dictionary<RecordMetricId, Expression<Func<LeagueSeasonMemberAggregatedStats, decimal>>>
            {
                [RecordMetricId.PointsFor] = stats => stats.PointsFor,
                [RecordMetricId.PointsForAverage] = stats => stats.PointsForAverage,
                [RecordMetricId.PointsAgainst] = stats => stats.PointsAgainst,
                [RecordMetricId.PointsAgainstAverage] = stats => stats.PointsAgainstAverage,
                [RecordMetricId.Wins] = stats => stats.Wins,
                [RecordMetricId.OutstandingPerformances] = stats => stats.OutstandingPerformances,
                [RecordMetricId.BlowoutWins] = stats => stats.BlowoutWins,
                [RecordMetricId.NarrowWins] = stats => stats.NarrowWins,
                [RecordMetricId.TopWeeks] = stats => stats.TopWeeks,
                [RecordMetricId.Losses] = stats => stats.Losses,
                [RecordMetricId.NarrowWins] = stats => stats.NarrowWins,
                [RecordMetricId.TopWeeks] = stats => stats.TopWeeks,
                [RecordMetricId.TopWeekPercentage] = stats => stats.TopWeekPercentage,
                [RecordMetricId.Losses] = stats => stats.Losses,
                [RecordMetricId.PoorPerformances] = stats => stats.PoorPerformances,
                [RecordMetricId.BlowoutLosses] = stats => stats.BlowoutLosses,
                [RecordMetricId.NarrowLosses] = stats => stats.NarrowLosses,
                [RecordMetricId.BottomWeeks] = stats => stats.BottomWeeks,
            };
    }
}
