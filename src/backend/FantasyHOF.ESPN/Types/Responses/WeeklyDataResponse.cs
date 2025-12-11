using FantasyHOF.ESPN.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Responses
{
    public class WeeklyDataResponse
    {
        public required List<ESPNMatchup> Schedule { get; set; }
    }
}
