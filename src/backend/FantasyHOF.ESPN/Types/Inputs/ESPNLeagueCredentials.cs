using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Inputs
{
    public record ESPNLeagueCredentials(string LeagueId, string? SWID, string? ESPNS2Id)
    {
        public bool IsPrivateLeague => !string.IsNullOrWhiteSpace(SWID);
    }
}
