using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Enums
{
    public enum ESPNErrorCode
    {
        AuthenticationFailed = 100,
        InvalidYear = 101,
        LeagueInvalid = 102,
        NoActiveYears = 103,
        GeneralHttpError = 104
    }
}
