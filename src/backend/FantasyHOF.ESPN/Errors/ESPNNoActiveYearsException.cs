using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNNoActiveYearsException : CodedException
    {
        public ESPNNoActiveYearsException() 
            : base(AppErrorCode.ESPNNoActiveYears, "The provided league has no years to pull data for. Try a different league.") { }
    }
}
