using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Mutations
{
    public sealed record AddLeagueMutationPayload(string jobId, LeagueImport Import);
}
