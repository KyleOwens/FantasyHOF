namespace FantasyHOF.Infrastructure.Enums
{
    public enum AppErrorCode
    {
        FantasyHOFForbidden,
        FantasyHOFNotFound,
        FantasyHOFLeagueImportExists,

        ESPNAuthenticationFailed = 200,
        ESPNInvalidYear,
        ESPNLeagueInvalid,
        ESPNNoActiveYears,
        ESPNGeneralHttpError,
    }
}
