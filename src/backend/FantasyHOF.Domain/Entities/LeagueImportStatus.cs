using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
