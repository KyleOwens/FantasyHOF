using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueImport
    {
        public int Id { get; private set; }

        public required string UserId { get; init; }
        public required FantasyProviderId ProviderId { get; init; }
        public required string ProviderleagueId { get; init; }
        public required LeagueImportStatusId StatusId { get; set; }
        public required int Progress { get; set; }

        public string? Error { get; set; }
        public int? LeagueId { get; set; }

        public User User { get; private set; } = null!;
        public FantasyProvider Provider { get; private set; } = null!;
        public LeagueImportStatus Status { get; private set; } = null!;
        public League League { get; private set; } = null!;
    }
}
