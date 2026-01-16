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
            [Parent] RecordDetails recordDetails) =>
             recordDetails.Entries;

        public static async Task<RecordDetails?> GetRecordDetailsAsync(
            string id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            var idParts = RecordDetails.ParseId(id);

            return await mediator.Send(new GetLeagueSingleRecordDetailsQuery(idParts.LeagueId, idParts.RecordTypeId), cancellationToken);
        }
    }
}
