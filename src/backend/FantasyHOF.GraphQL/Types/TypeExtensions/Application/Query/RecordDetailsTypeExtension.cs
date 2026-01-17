using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.Types.Queries.Records;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Application.Query
{
    [Node]
    [ExtendObjectType<RecordDetails>]
    public class RecordDetailsTypeExtension
    {
        [UsePaging]
        public async Task<IQueryable<RecordEntry>> GetEntriesAsync(
            [Parent] RecordDetails recordDetails,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(
                new GetLeagueSingleRecordEntriesQuery(recordDetails.LeagueId, recordDetails.Metadata.RecordTypeId)
                , cancellationToken
            );
        }

        public static RecordDetails GetRecordDetails(string id)
        {
            var (RecordTypeId, LeagueId) = RecordDetails.ParseId(id);

            return new RecordDetails(LeagueId, RecordTypeId);
        }
    }
}
