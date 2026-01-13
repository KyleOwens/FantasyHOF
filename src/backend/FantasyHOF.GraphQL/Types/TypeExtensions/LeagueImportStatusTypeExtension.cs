using FantasyHOF.Application.Queries.LeagueImportStatusQueries;
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
			return await mediator.Send(new GetLeagueImportStatusByIdQuery((LeagueImportStatusId) id), cancellationToken);
		}
    }
}
