using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types
{
    public class ESPNFantasyTeam
    {
        public int Id { get; set; }
        public string Abbrev { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public string Name { get; set; } = default!;
        public List<string> Owners { get; set; } = [];
    }
}
