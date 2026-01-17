using FantasyHOF.Application.Enums;
using FantasyHOF.EntityFramework.Extensions;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordMetadata(RecordTypeId type)
    {
        public RecordTypeId RecordTypeId { get; private set; } = type;

        public string DisplayName => RecordTypeId.GetMetadata().DisplayName;
        public string Description => RecordTypeId.GetMetadata().Description;
        public RecordCategoryId Category => RecordTypeId.GetMetadata().Category;
        public string CategoryDisplayName => Category.GetDisplayName();
        public RecordSentiment Sentiment => RecordTypeId.GetMetadata().Sentiment;
        public RecordMetricId MetricId => RecordTypeId.GetMetadata().Metric;
        public string Unit => MetricId.GetDisplayName();
        public RecordMetricType MetricType => RecordTypeId.GetMetadata().MetricType;
        public string IconURI => RecordTypeId.GetMetadata().IconURI;
        public SortDirection SortDirection => RecordTypeId.GetMetadata().SortDirection;
    }
}
