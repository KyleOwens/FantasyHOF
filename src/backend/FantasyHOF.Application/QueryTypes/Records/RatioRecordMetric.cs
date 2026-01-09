using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
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
