using FantasyHOF.ESPN.Types.Models;

namespace FantasyHOF.ESPN.Types.Responses
{
    public class LeagueDataResponse
    {
        public required int SeasonId { get; set; }
        public ESPNLeagueSettings Settings { get; set; } = default!;
        public List<ESPNFantasyMember> Members { get; set; } = [];
        public List<ESPNFantasyTeam> Teams { get; set; } = [];
    }
}
