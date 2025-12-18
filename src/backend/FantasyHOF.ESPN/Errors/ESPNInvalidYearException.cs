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
    public class ESPNInvalidYearException : CodedException
    {
        public ESPNInvalidYearException() 
            : base(AppErrorCode.ESPNInvalidYear, "The year provided was not found for this league") { }
    }
}
