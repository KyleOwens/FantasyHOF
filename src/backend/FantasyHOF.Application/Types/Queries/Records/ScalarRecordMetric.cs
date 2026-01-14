using FantasyHOF.Application.Enums;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record ScalarRecordMetric(decimal Value, RecordMetricId MetricId)
        : RecordMetric(Value, MetricId);
}
