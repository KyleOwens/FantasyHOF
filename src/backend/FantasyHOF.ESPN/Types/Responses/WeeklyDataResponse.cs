using FantasyHOF.ESPN.Types.Models;

namespace FantasyHOF.ESPN.Types.Responses
{
    public class WeeklyDataResponse
    {
        public required int SeasonId { get; set; }
        public required List<ESPNMatchup> Schedule { get; set; }
    }
}
