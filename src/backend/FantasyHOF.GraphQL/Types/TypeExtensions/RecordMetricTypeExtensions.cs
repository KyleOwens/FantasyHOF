using FantasyHOF.Application.Types.Queries.Records;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    internal class RecordMetricTypeExtension : InterfaceType<RecordMetric>;

    internal class ScalarRecordMetricTypeExtension : ObjectType<ScalarRecordMetric>
    {
        protected override void Configure(IObjectTypeDescriptor<ScalarRecordMetric> descriptor)
        {
            descriptor.Implements<RecordMetricTypeExtension>();
        }
    }

    internal class RatioRecordMetricTypeExtension : ObjectType<RatioRecordMetric>
    {
        protected override void Configure(IObjectTypeDescriptor<RatioRecordMetric> descriptor)
        {
            descriptor.Implements<RecordMetricTypeExtension>();
        }
    }
}
