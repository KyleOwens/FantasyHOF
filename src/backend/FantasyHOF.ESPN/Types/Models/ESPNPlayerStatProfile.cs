namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNPlayerStatProfile
    {
        public required float AppliedTotal { get; set; }
        public required int StatSourceId { get; set; }
        public required Dictionary<int, float> AppliedStats { get;set; }
        public required Dictionary<int, float> Stats { get; set; }
    }
}