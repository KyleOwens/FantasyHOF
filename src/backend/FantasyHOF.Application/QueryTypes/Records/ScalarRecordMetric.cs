using FantasyHOF.Application.Enums;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record ScalarRecordMetric(decimal Value, RecordMetricId MetricId)
        : RecordMetric(Value, MetricId);
}
