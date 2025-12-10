using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Responses
{
    public class MNavResponse
    {
        public List<ESPNFantasyMember> Members { get; set; } = [];
        public List<ESPNFantasyTeam> Teams { get; set; } = [];
    }
}
