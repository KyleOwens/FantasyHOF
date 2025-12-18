using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Infrastructure.Enums
{
    public enum AppErrorCode
    {
        ESPNAuthenticationFailed,
        ESPNInvalidYear,
        ESPNLeagueInvalid,
        ESPNNoActiveYears,
        ESPNGeneralHttpError
    }
}
