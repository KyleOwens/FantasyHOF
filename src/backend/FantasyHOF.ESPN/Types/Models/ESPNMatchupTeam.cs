namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNMatchupTeam
    {
        public required int TeamId { get; set; }
        public required decimal TotalPoints { get; set; }
        public required ESPNRoster rosterForCurrentScoringPeriod { get; set; }
    }
}