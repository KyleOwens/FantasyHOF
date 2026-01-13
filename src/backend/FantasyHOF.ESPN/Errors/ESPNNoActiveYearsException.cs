using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNNoActiveYearsException : CodedException
    {
        public ESPNNoActiveYearsException()
            : base(AppErrorCode.ESPNNoActiveYears, "The provided league has no years to pull data for. Try a different league.") { }
    }
}
