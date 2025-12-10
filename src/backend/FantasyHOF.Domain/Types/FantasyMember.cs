using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyMember
    {
        public string Id { get; init; } = default!;
        public string DisplayName { get; init; } = default!;
        public string FirstName { get; init; } = default!;
        public string LastName { get; set; } = default!;
        public bool IsLeagueCreator { get; init; }
        public bool IsLeagueManager { get; init; }

        public List<FantasyTeam> Teams { get; init; } = [];
    }
}
