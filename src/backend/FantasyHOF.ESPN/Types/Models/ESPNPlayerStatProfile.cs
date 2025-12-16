namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNPlayerStatProfile
    {
        public required decimal AppliedTotal { get; set; }
        public required int StatSourceId { get; set; }
        public required Dictionary<int, decimal> AppliedStats { get;set; }
        public required Dictionary<int, decimal> Stats { get; set; }
    }
}