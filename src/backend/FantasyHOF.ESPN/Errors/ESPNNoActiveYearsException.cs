using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Errors
{
    internal class ESPNNoActiveYearsException : CodedException<ESPNErrorCode>
    {
        public ESPNNoActiveYearsException() 
            : base(ESPNErrorCode.NoActiveYears, "This league has no years to pull data for")
        {
            
        }
    }
}
