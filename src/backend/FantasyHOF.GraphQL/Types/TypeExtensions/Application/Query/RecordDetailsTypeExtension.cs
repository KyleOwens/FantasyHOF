using FantasyHOF.Application.Types.Queries.Records;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Application.Query
{
    [ExtendObjectType<RecordDetails>]
    public class RecordDetailsTypeExtension
    {
        [UsePaging]
        public async Task<IQueryable<RecordEntry>> GetEntriesAsync(
            [Parent] RecordDetails recordDetails) =>
             recordDetails.Entries;
    }
}
