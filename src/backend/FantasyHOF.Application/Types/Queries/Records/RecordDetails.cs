using FantasyHOF.Application.Enums;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordDetails(int leagueId, RecordTypeId recordTypeId)
    {
        public string Id => $"{(int)Metadata.Type}:{leagueId}";

        public int LeagueId => leagueId;
        public RecordMetadata Metadata { get; private set; } = new RecordMetadata(recordTypeId);

        public static (RecordTypeId RecordTypeId, int LeagueId) ParseId(string id)
        {
            string[] parts = id.Split(':');

            return (Enum.Parse<RecordTypeId>(parts[0]), int.Parse(parts[1]));
        }
    }
}
