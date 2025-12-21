using FantasyHOF.Application.Queries.FantasyMemberQueries;
using FantasyHOF.Domain.Types;
using MediatR;

namespace FantasyHOF.GraphQL.Types.DataLoaders
{
	internal static class FantasyMembersByIdsDataLoaderDefinition
	{
		[DataLoader]
		public static async Task<Dictionary<int, FantasyMember>> GetFantasyMembersByIdsAsync(
			IReadOnlyList<int> ids,
			IMediator mediator,
			CancellationToken cancellationToken)
		{
			var members = await mediator.Send(
				new GetFantasyMembersByIdsQuery(ids),
				cancellationToken);

			return members.ToDictionary(member => member.Id);
		}
	}
}