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
    public class ESPNAuthenticationException : CodedException
    {
        public ESPNAuthenticationException()
            : base(AppErrorCode.ESPNAuthenticationFailed, "Authentication with ESPN failed") { }
    }
}
