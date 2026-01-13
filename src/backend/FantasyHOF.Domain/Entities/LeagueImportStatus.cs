using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Entities
{
    public class LeagueImportStatus
    {
        public LeagueImportStatusId Id { get; private set; }
        public string Name { get; private set; } = null!;

        protected LeagueImportStatus() { }

        public LeagueImportStatus(LeagueImportStatusId id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
