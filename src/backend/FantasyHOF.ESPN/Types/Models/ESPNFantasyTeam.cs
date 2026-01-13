namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNFantasyTeam
    {
        public int Id { get; set; }
        public int RankCalculatedFinal { get; set; }
        public string Abbrev { get; set; } = default!;
        public string? Logo { get; set; } = default!;
        public string Name { get; set; } = default!;
        public ESPNSeasonStats Record { get; set; } = default!;
        public List<string> Owners { get; set; } = [];
    }
}
