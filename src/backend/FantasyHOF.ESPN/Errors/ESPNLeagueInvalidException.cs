using FantasyHOF.Infrastructure.Enums;
using FantasyHOF.Infrastructure.Exceptions;

namespace FantasyHOF.ESPN.Errors
{
    public class ESPNLeagueInvalidException : CodedException
    {
        public ESPNLeagueInvalidException()
            : base(AppErrorCode.ESPNLeagueInvalid, $"An ESPN League with with the provided Id does not exist. Ensure the league Id you entered is correct") { }
    }
}
