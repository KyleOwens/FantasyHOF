namespace FantasyHOF.ESPN.Types.Models
{
    public class ESPNPlayer
    {
        public required int Id { get; set; }
        public required int ProTeamId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string FullName { get; set; }
        public required List<ESPNPlayerStatProfile> Stats { get; set; }
    }
}