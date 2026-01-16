using FantasyHOF.Application.Enums;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordDetails(int leagueId, RecordMetadata metadata, IQueryable<RecordEntry> entries)
    {
        public string Id => $"{(int)Metadata.Type}:{leagueId}";

        public RecordMetadata Metadata { get; private set; } = metadata;
        public IQueryable<RecordEntry> Entries { get; private set; } = entries;

        public static (RecordTypeId RecordTypeId, int LeagueId) ParseId(string id)
        {
            string[] parts = id.Split(':');

            return (Enum.Parse<RecordTypeId>(parts[0]), int.Parse(parts[1]));
        }
    }
}
