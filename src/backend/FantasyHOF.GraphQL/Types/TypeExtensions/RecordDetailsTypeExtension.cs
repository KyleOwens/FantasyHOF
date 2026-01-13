using FantasyHOF.Application.QueryTypes.Records;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    public class RecordDetailsTypeExtension : InterfaceType<RecordDetails>;

    public class LeagueRecordDetailsTypeExtension : ObjectType<LeagueRecordDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<LeagueRecordDetails> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }

    public class SeasonalRecordDetailsTypeExtension : ObjectType<SeasonalRecordDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<SeasonalRecordDetails> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }

    public class WeeklyRecordDetailsTypeExtension : ObjectType<WeeklyRecordDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<WeeklyRecordDetails> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }

    public class PlayerRecordDetailsTypeExtension : ObjectType<PlayerRecordDetails>
    {
        protected override void Configure(IObjectTypeDescriptor<PlayerRecordDetails> descriptor)
        {
            descriptor.Implements<RecordDetailsTypeExtension>();
        }
    }
}
