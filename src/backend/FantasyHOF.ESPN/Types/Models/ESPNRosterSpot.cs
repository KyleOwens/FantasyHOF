
using FantasyHOF.ESPN.Enums;
using System.Text.Json.Serialization;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNRosterSpot
    {
        public required ESPNLineupSlotId lineupSlotId { get; set; }
        public required ESPNPlayerEntry PlayerPoolEntry { get; set; }
    }
}