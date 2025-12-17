using FantasyHOF.ESPN.Enums;
using FantasyHOF.Infrastructure.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNAuthenticationException : CodedException<ESPNErrorCode>
    {
        public ESPNAuthenticationException()
            : base(ESPNErrorCode.AuthenticationFailed, "Authentication with ESPN failed") { }
    }
}
