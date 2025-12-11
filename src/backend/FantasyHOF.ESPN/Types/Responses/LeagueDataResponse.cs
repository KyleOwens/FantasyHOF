using FantasyHOF.ESPN.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Responses
{
    public class LeagueDataResposne
    {
        public ESPNLeagueSettings Settings { get; set; } = default!;
        public List<ESPNFantasyMember> Members { get; set; } = [];
        public List<ESPNFantasyTeam> Teams { get; set; } = [];
    }
}
