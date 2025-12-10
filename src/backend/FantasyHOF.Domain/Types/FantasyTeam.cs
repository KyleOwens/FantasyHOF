using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types
{
    public class FantasyTeam
    {
        public int Id { get; init; }
        public string Abbreviation { get; init; } = default!;
        public string LogoURL { get; init; } = default!;
        public string Name { get; init; } = default!;
        public List<string> OwnerIDs { get; init; } = [];
    }
}
