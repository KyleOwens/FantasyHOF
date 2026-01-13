
using FantasyHOF.Application.Queries.LeagueImportStatusQueries;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class LeagueImportStatusesByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<LeagueImportStatusId, LeagueImportStatus>> GetLeagueImportStatusesByIdsAsync(
			IReadOnlyList<LeagueImportStatusId> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var statuses = await mediator.Send(
				new GetLeagueImportStatusesByIdsQuery(ids),
				cancellationToken);

			return statuses.ToDictionary(status => status.Id);
		}
	}
}