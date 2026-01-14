using FantasyHOF.Application.Enums;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class RecordType
    {
        public RecordTypeId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected RecordType() { }

        public RecordType(RecordTypeId id)
        {
            Id = id;
            Name = id.GetMetadata().DisplayName;
        }
    }
}