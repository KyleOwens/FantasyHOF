namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNFantasyMember
    {
        public string Id { get; set; } = default!;
        public string DisplayName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public bool IsLeagueCreator { get; set; }
        public bool IsLeagueManager { get; set; }
    }
}
