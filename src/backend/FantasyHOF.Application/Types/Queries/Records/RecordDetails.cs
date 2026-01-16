namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordDetails(RecordMetadata metadata, List<RecordEntry> entries)
    {
        public RecordMetadata Metadata { get; private set; } = metadata;
        public List<RecordEntry> Entries { get; private set; } = entries;
    }
}
