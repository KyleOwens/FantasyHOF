using FantasyHOF.Application.Queries.SportQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [Node]
    [ExtendObjectType<Sport>]
    internal class SportTypeExtension
	{
        [ID]
        public int Id([Parent] Sport sport) => (int)sport.Id;
        public SportId Value([Parent] Sport sport) => sport.Id;

        public static async Task<Sport?> GetSportAsync(
			int id,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			return await mediator.Send(new GetSportByIdQuery((SportId) id), cancellationToken);
		}
    }
}
