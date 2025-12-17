namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNPlayerStatProfile
    {
        public required int StatSourceId { get; set; }
        public required Dictionary<int, decimal> Stats { get; set; }

        public Dictionary<int, decimal>? AppliedStats { get; set; } // this is null pre 2018
    }
}