using FantasyHOF.Application.Queries.LeagueImportQueries;
using FantasyHOF.Application.Queries.LeagueQueries;
using FantasyHOF.Application.Queries.UserQueries;
using FantasyHOF.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<User>]
    internal class UserTypeExtension
    {
        public async Task<IEnumerable<League>> GetLeaguesAsync(IMediator mediator, CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetUserLeaguesQuery(), cancellationToken);
        }

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
