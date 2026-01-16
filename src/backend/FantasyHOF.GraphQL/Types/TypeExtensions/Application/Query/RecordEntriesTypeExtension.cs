using FantasyHOF.Application.Types.Queries.Records;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Application.Query
{
    public class RecordEntryTypeExtension : InterfaceType<RecordEntry>;

    public class LeagueRecordDetailsTypeExtension : ObjectType<LeagueRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<LeagueRecordEntry> descriptor)
        {
            descriptor.Implements<RecordEntryTypeExtension>();
        }
    }

    public class SeasonalRecordDetailsTypeExtension : ObjectType<SeasonalRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<SeasonalRecordEntry> descriptor)
        {
            descriptor.Implements<RecordEntryTypeExtension>();
        }
    }

    public class WeeklyRecordDetailsTypeExtension : ObjectType<WeeklyRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<WeeklyRecordEntry> descriptor)
        {
            descriptor.Implements<RecordEntryTypeExtension>();
        }
    }

    public class PlayerRecordDetailsTypeExtension : ObjectType<PlayerRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<PlayerRecordEntry> descriptor)
        {
            descriptor.Implements<RecordEntryTypeExtension>();
        }
    }
}
