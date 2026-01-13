using FantasyHOF.ESPN.Types.Models;

namespace FantasyHOF.ESPN.Types.Responses
{
    internal class PreviousYearsResponse
    {
        public required int SeasonId { get; set; }
        public required ESPNLeagueStatus Status { get; set; }
    }
}
