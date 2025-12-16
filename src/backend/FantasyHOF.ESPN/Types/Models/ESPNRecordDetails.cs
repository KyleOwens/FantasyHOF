namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNRecordDetails
    {
        public float GamesBack { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Ties { get; set; }
        public decimal Percentage { get; set; }
        public decimal PointsAgainst { get; set; }
        public decimal PointsFor { get; set; }
    }
}