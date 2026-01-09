using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record ScalarRecordMetric(decimal Value, RecordMetricId MetricId)
        : RecordMetric(Value, MetricId);
}
