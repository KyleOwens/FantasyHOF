using FantasyHOF.ESPN.Types.Models;

namespace FantasyHOF.ESPN.Types.Outputs
{
    public class ESPNWeeklyLeagueData
    {
        public required int Year { get; set; }
        public required int Week { get; set; }
        public required List<ESPNMatchup> Matchups { get; set; }
    }
}
