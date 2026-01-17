using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.Domain.Enums;
using System.Linq.Expressions;

namespace FantasyHOF.Application.Services.Registries
{
    public static class WeeklyMetricSelectorRegistry
    {
        public static readonly IReadOnlyDictionary<RecordMetricId, Expression<Func<WeeklyAggregationData, decimal>>> Selectors =
            new Dictionary<RecordMetricId, Expression<Func<WeeklyAggregationData, decimal>>>
            {
                [RecordMetricId.Score] = stats => stats.Score,
                [RecordMetricId.PlayoffScore] = stats => stats.Score,
                [RecordMetricId.VictoryScoreMargin] = stats => stats.ScoreMargin,
                [RecordMetricId.PlayoffVictoryScoreMargin] = stats => stats.ScoreMargin,
                [RecordMetricId.WinScore] = stats => stats.Score,
                [RecordMetricId.LossScore] = stats => stats.Score,
            };

        public static readonly IReadOnlyDictionary<RecordMetricId, Expression<Func<WeeklyAggregationData, bool>>> Filters =
            new Dictionary<RecordMetricId, Expression<Func<WeeklyAggregationData, bool>>>
            {
                [RecordMetricId.PlayoffScore] = stats => stats.MatchupTypeId != MatchupTypeId.RegularSeason,
                [RecordMetricId.VictoryScoreMargin] = stats => stats.MatchupOutcomeId == MatchupOutcomeId.Win,
                [RecordMetricId.PlayoffVictoryScoreMargin] = stats => stats.MatchupTypeId != MatchupTypeId.RegularSeason &&
                                                                      stats.MatchupOutcomeId == MatchupOutcomeId.Win,
                [RecordMetricId.WinScore] = stats => stats.MatchupOutcomeId == MatchupOutcomeId.Win,
                [RecordMetricId.LossScore] = stats => stats.MatchupOutcomeId == MatchupOutcomeId.Loss,
            };
    }
}
