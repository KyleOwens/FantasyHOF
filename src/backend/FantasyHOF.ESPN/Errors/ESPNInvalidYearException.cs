using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNInvalidYearException : CodedException
    {
        public ESPNInvalidYearException()
            : base(AppErrorCode.ESPNInvalidYear, "The year provided was not found for this league") { }
    }
}
