using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNAuthenticationException : CodedException
    {
        public ESPNAuthenticationException()
            : base(AppErrorCode.ESPNAuthenticationFailed, "Authentication with ESPN failed. Ensure your SWID and ESPN S2 cookies are correct") { }
    }
}
