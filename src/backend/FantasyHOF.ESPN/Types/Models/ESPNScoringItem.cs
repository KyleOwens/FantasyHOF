using FantasyHOF.ESPN.Enums;

namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNScoringItem
    {
        public ESPNStatId StatId { get; set; }
        public bool IsReverseItem { get; set; }
        public decimal LeagueRanking { get; set; }
        public decimal LeagueTotal { get; set; }
        public decimal Points { get; set; }
    }
}