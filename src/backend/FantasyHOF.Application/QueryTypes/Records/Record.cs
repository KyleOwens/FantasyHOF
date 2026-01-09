using FantasyHOF.Application.Enums;
using FantasyHOF.Application.QueryTypes.Records;
using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class Record(FantasyMember member, RecordTypeId type, RecordMetric metric)
    {
        public RecordTypeId Type { get; private set; } = type;
        public FantasyMember Member { get; private set; } = member;
        public RecordMetric Metric { get; private set; } = metric;

        public string DisplayName => Type.GetMetadata().DisplayName;
        public RecordCategoryId Category => Type.GetMetadata().Category;
        public RecordSentiment Sentiment => Type.GetMetadata().Sentiment;
        public RecordMetricId MetricId => Type.GetMetadata().Metric;
        public RecordMetricType MetricType => Type.GetMetadata().MetricType;
        public string IconURI => Type.GetMetadata().IconURI;
        public SortDirection SortDirection => Type.GetMetadata().SortDirection;
    }
}
