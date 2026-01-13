using FantasyHOF.ESPN.Types.Models;

namespace FantasyHOF.ESPN.Types.Outputs
{
    public record ESPNSeasonalLeagueData(int Year, ESPNLeagueSettings LeagueSettings, List<ESPNFantasyMember> Members, List<ESPNFantasyTeam> Teams)
    {
    }
}
