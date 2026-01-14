using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record RatioRecordMetric(
        RecordMetricId MetricId,
        decimal Numerator,
        RecordMetricId NumeratorMetricId,
        decimal Denominator,
        RecordMetricId DenominatorMetricId
    ) : RecordMetric(
        Denominator == 0 ? 0m : Numerator / Denominator,
        MetricId
    )
    {
        public string NumeratorUnit => NumeratorMetricId.GetDisplayName();
        public string DenominatorUnit => DenominatorMetricId.GetDisplayName();
    }
}
