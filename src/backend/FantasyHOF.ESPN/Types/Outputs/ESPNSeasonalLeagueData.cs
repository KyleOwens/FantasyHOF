using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Outputs
{
    public record ESPNSeasonalLeagueData(int Year, ESPNLeagueSettings LeagueSettings, List<ESPNFantasyMember> Members, List<ESPNFantasyTeam> Teams)
    {
    }
}
