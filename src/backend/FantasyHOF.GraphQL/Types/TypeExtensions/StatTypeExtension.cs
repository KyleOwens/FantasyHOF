using FantasyHOF.Application.Queries.StatQueries;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType(typeof(Stat))]
    internal class StatTypeExtension
    {
        [ID]
        public int Id([Parent] Stat stat) => (int) stat.Id;
        public StatId Value([Parent] Stat stat) => stat.Id;

        public static async Task<Stat?> GetStatAsync(
            int id,
            IMediator mediator,
            CancellationToken cancellationToken)
        {
            return await mediator.Send(new GetStatByIdQuery((StatId)id), cancellationToken);
        }
    }
}
