using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Errors
{
    internal class ESPNInvalidYearException : CodedException<ESPNErrorCode>
    {
        public ESPNInvalidYearException() 
            : base(ESPNErrorCode.InvalidYear, "The year provided was not found for this league") { }
    }
}
