using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public abstract class Record(FantasyMember member, RecordTypeId recordTypeId, RecordMetric metric)
    {
        public FantasyMember Member { get; private set; } = member;
        public RecordMetric Metric { get; private set; } = metric;
        public RecordMetadata Metadata { get; private set; } = new RecordMetadata(recordTypeId);
    }
}
