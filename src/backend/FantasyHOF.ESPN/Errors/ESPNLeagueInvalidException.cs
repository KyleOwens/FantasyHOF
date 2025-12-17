using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNLeagueInvalidException : CodedException<ESPNErrorCode>
    {
        public ESPNLeagueInvalidException() 
            : base (ESPNErrorCode.LeagueInvalid, $"An ESPN League with with this league Id does not exist") { }
    }
}
