namespace FantasyHOF.ESPN
{
    public interface IESPNHTTPService
    {
        public List<string> LoadLeague(string leagueId, string swid, string espn2id);
    }
    
    public class ESPNHTTPClient : IESPNHTTPService
    {
        private readonly HttpClient _client;

        public ESPNHTTPClient(HttpClient client)
        {
            client.BaseAddress = new Uri("https://fantasy.espn.com/apis/v3");
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            _client = client;
        }

        public List<string> LoadLeague(string leagueId, string swid, string espn2id)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, )
        }

        private List<string> LoadLeagueYears()
    }
}
