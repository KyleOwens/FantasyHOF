using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueImport
    {
        public int Id { get; private set; }

        public required Guid UserId { get; set; }
        public required FantasyProviderId ProviderId { get; set; }
        public required string ProviderleagueId { get; set; }
        public required LeagueImportStatusId StatusId { get; set; }
        public required int Progress { get; set; }
        public string? Error { get; set; }

        public User User { get; private set; } = null!;
        public FantasyProvider Provider { get; private set; } = null!;
        public LeagueImportStatus Status { get; private set; } = null!;
    }
}
