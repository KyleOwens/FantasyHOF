using FantasyHOF.Application.Types.Queries.Records;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    public class RecordDetailsTypeExtension : InterfaceType<RecordEntry>;

    public class LeagueRecordDetailsTypeExtension : ObjectType<LeagueRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<LeagueRecordEntry> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }

    public class SeasonalRecordDetailsTypeExtension : ObjectType<SeasonalRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<SeasonalRecordEntry> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }

    public class WeeklyRecordDetailsTypeExtension : ObjectType<WeeklyRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<WeeklyRecordEntry> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }

    public class PlayerRecordDetailsTypeExtension : ObjectType<PlayerRecordEntry>
    {
        protected override void Configure(IObjectTypeDescriptor<PlayerRecordEntry> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }
}
