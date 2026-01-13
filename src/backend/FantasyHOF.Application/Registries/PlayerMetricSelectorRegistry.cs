using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Application.Registries
{
    public static class PlayerMetricSelectorRegistry
    {
        public static readonly IReadOnlyDictionary<RecordMetricId, Expression<Func<PlayerAggregationData, decimal>>> Selectors =
            new Dictionary<RecordMetricId, Expression<Func<PlayerAggregationData, decimal>>>
            {
                [RecordMetricId.PointsScored] = stats => stats.PointsScored,
                [RecordMetricId.PointsScoredNonQB] = stats => stats.PointsScored,
                [RecordMetricId.PointsScoredNonDST] = stats => stats.PointsScored,
            };

        public static readonly IReadOnlyDictionary<RecordMetricId, Expression<Func<PlayerAggregationData, bool>>> Filters =
            new Dictionary<RecordMetricId, Expression<Func<PlayerAggregationData, bool>>>
            {
                [RecordMetricId.PointsScored] = stats => stats.PositionId != PositionId.BE,
                [RecordMetricId.PointsScoredNonQB] = stats => stats.PositionId != PositionId.BE &&
                                                              stats.PositionId != PositionId.QB &&
                                                              stats.PositionId != PositionId.Unknown,
                [RecordMetricId.PointsScoredNonDST] = stats => stats.PositionId != PositionId.BE &&
                                                               stats.PositionId != PositionId.DST &&
                                                               stats.PositionId != PositionId.Unknown,
            };
    }
}
