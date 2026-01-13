using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public abstract record RecordMetric(decimal Value, RecordMetricId MetricId)
    {
        public string Unit => MetricId.GetDisplayName();
    };
}
