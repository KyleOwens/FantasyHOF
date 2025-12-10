using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types
{
    public class ESPNFantasyMember
    {
        public string Id { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public bool IsLeagueCreator { get; set; }
        public bool IsLeagueManager { get; set; }
    }
}
