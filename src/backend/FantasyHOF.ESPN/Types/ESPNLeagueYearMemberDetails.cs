using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types
{
    public record ESPNLeagueYearMemberDetails(int Year, List<ESPNFantasyMember> Members, List<ESPNFantasyTeam> Teams)
    {
    }
}
