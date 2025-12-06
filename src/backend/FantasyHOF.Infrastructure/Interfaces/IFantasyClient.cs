namespace FantasyHOF.Infrastructure.Interfaces
{
    public interface IFantasyClient
    {
        public List<string> LoadLeague(string leagueId, string swid, string espn2id);
    }
}
