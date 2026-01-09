using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public class RecordMetadata
    {
        public RecordMetadata(RecordTypeId type)
        {
            Type = type;
        }

        public RecordTypeId Type { get; private set; }

        public string DisplayName => Type.GetMetadata().DisplayName;
        public RecordCategoryId Category => Type.GetMetadata().Category;
        public RecordSentiment Sentiment => Type.GetMetadata().Sentiment;
        public RecordMetricId Metric => Type.GetMetadata().Metric;
        public RecordMetricType MetricType => Type.GetMetadata().MetricType;
        public string IconURI => Type.GetMetadata().IconURI;
        public SortDirection SortDirection => Type.GetMetadata().SortDirection;
    }
}
