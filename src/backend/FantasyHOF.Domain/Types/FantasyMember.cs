using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyMember
    {
        public required string Id { get; init; }
        public required string DisplayName { get; init; }
        public required string FirstName { get; init; }
        public required string LastName { get; set; }
        public required bool IsLeagueCreator { get; init; }
        public required bool IsLeagueManager { get; init; }

        public required List<FantasyTeam> Teams { get; init; }
    }
}
