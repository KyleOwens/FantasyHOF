namespace FantasyHOF.Domain.Types
{
    public class FantasyScoringItem
    {
        public required FantasyStat Stat { get; set; }
        public required float Points { get; set; }
    }
}