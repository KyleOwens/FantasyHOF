using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.QueryTypes
{
    public sealed record AddLeagueMutationPayload(string jobId, LeagueImport Import);
}
