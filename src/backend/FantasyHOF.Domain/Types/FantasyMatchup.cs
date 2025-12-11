namespace FantasyHOF.Domain.Types
{
    public class FantasyMatchup
    {
        // week
        //score
        public required FantasyTeam Opponent { get; set; }
        public required FantasyRoster Roster { get; set; }
    }
}