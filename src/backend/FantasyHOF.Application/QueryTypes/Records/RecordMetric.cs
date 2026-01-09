using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public abstract record RecordMetric(decimal Value, RecordMetricId MetricId)
    {
        public string Unit => MetricId.GetDisplayName();
    };
}
