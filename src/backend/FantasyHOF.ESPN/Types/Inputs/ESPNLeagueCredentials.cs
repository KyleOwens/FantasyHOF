namespace FantasyHOF.ESPN.Types.Inputs
{
    public record ESPNLeagueCredentials(string LeagueId, string? SWID, string? ESPNS2Id)
    {
        public bool IsPrivateLeague => !string.IsNullOrWhiteSpace(SWID);

        public override string ToString()
        {
            return LeagueId;
        }
    }
}
