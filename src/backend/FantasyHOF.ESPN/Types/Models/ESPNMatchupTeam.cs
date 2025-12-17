using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNMatchupTeam
    {
        public required int TeamId { get; set; }
        public required decimal TotalPoints { get; set; }

        [JsonInclude]
        internal ESPNRoster? RosterForMatchupPeriod { get; init; }

        [JsonInclude]
        internal ESPNRoster? RosterForCurrentScoringPeriod { get; init; }

        [NotMapped]
        public ESPNRoster? Roster => 
            RosterForCurrentScoringPeriod is not null ? 
            RosterForCurrentScoringPeriod : 
            RosterForMatchupPeriod;
    }
}