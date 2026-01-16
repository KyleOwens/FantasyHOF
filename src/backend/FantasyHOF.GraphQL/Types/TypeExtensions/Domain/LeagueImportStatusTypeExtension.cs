using FantasyHOF.Application.Queries.LeagueImportStatusQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<LeagueImportStatus>]
    internal class LeagueImportStatusTypeExtension
    {
        [ID]
        public int Id([Parent] LeagueImportStatus status) => (int)status.Id;
        public LeagueImportStatusId Value([Parent] LeagueImportStatus status) => status.Id;

        public static async Task<LeagueImportStatus?> GetLeagueImportStatusAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueImportStatusByIdQuery((LeagueImportStatusId)id), cancellationToken);
        }
    }
}
