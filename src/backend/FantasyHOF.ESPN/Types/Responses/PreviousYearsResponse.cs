using FantasyHOF.ESPN.Types.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Types.Responses
{
    internal class PreviousYearsResponse
    {
        public required int SeasonId { get; set; }
        public required ESPNLeagueStatus Status { get; set; }
    }
}
