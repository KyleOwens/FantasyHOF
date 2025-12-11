using FantasyHOF.ESPN.Types.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN
{
    public interface IESPNAPIClientBuilder
    {
        ESPNAPIClient Build(ESPNLeagueCredentials credentials);
    }

    public class ESPNAPIClientBuilder : IESPNAPIClientBuilder
    {
        private HttpClient _client;

        public ESPNAPIClientBuilder(HttpClient client)
        {
            _client = client;   
        }

        public ESPNAPIClient Build(ESPNLeagueCredentials credentials)
        {
            return new ESPNAPIClient(_client, credentials);
        }
    }
}
