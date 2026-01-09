using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Types.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Application.Registries
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
