using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordMetadata
    {
        public RecordMetadata(RecordTypeId type)
        {
            Type = type;
        }

        public RecordTypeId Type { get; private set; }

        public string DisplayName => Type.GetMetadata().DisplayName;
        public string Description => Type.GetMetadata().Description;
        public RecordCategoryId Category => Type.GetMetadata().Category;
        public string CategoryDisplayName => Category.GetDisplayName();
        public RecordSentiment Sentiment => Type.GetMetadata().Sentiment;
        public RecordMetricId MetricId => Type.GetMetadata().Metric;
        public string Unit => MetricId.GetDisplayName();
        public RecordMetricType MetricType => Type.GetMetadata().MetricType;
        public string IconURI => Type.GetMetadata().IconURI;
        public SortDirection SortDirection => Type.GetMetadata().SortDirection;
    }
}
