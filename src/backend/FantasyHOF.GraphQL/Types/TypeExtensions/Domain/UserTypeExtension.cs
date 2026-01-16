using FantasyHOF.Application.Queries.LeagueImportQueries;
using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.Queries.UserQueries;
using FantasyHOF.Domain.Entities;
using MediatR;

namespace FantasyHOF.GraphQL.Types.TypeExtensions.Domain
{
    [Node]
    [ExtendObjectType<User>]
    internal class UserTypeExtension
    {
        public async Task<League> GetLeagueAsync([ID<League>] int leagueId, IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueByIdQuery(leagueId), cancellationToken);
        }

        [UsePaging]
        public async Task<IEnumerable<League>> GetLeaguesAsync(IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUserLeaguesQuery(), cancellationToken);
        }

        [UsePaging]
        public async Task<IEnumerable<LeagueImport>> GetLeagueImportsAsync(IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetLeagueImportsByCurrentUserQuery(), cancellationToken);
        }

        public static async Task<User?> GetUserAsync(
            Guid id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        }
    }
}
