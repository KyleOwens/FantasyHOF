namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordDetails(RecordMetadata metadata, IQueryable<RecordEntry> entries)
    {
        public RecordMetadata Metadata { get; private set; } = metadata;
        public IQueryable<RecordEntry> Entries { get; private set; } = entries;
    }
}
