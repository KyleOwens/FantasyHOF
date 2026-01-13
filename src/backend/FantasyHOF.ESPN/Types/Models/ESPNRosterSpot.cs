
using FantasyHOF.ESPN.Enums;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNRosterSpot
    {
        public required ESPNLineupSlotId lineupSlotId { get; set; }
        public required ESPNPlayerEntry PlayerPoolEntry { get; set; }
    }
}