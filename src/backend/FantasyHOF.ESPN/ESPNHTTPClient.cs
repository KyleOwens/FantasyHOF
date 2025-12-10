using FantasyHOF.ESPN.Errors;
using FantasyHOF.ESPN.Types;
using FantasyHOF.ESPN.Types.Responses;
using FantasyHOF.Infrastructure.Extensions;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace FantasyHOF.ESPN
{
    public interface IESPNHTTPService
    {
        public Task<List<ESPNLeagueYearMemberDetails>> LoadAllMemberData(ESPNLeagueCredentials credentials);
    }

    public class ESPNHTTPClient : IESPNHTTPService
    {
        private readonly HttpClient _client;
        private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        public ESPNHTTPClient(HttpClient client)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            _client = client;
        }

        public async Task<List<ESPNLeagueYearMemberDetails>> LoadAllMemberData(ESPNLeagueCredentials credentials)
        {
            IEnumerable<int> leagueYears = (await LoadLeagueYears(credentials))
                .Where(year => year >= 2018); // temporary until pre-2018 API is fleshed out

            List<ESPNLeagueYearMemberDetails> memberDetails = new();

            foreach (int year in leagueYears)
            {
                HttpRequestMessage request = ESPNRequestBuilder.ForLeague(credentials, year)
                    .WithViews(ESPNView.mNav)
                    .Build();

                MNavResponse response = await SendAPIRequestAsync<MNavResponse>(request);

                memberDetails.Add(new ESPNLeagueYearMemberDetails(year, response.Members, response.Teams));
            }

            return memberDetails;
        }

        private async Task<TAPIResponseType> SendAPIRequestAsync<TAPIResponseType>(HttpRequestMessage request)
        {
            HttpResponseMessage apiResponse = await _client.SendAsync(request);

            switch(apiResponse.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new ESPNLeagueInvalidException();
                case HttpStatusCode.NotFound:
                    throw new ESPNInvalidYearException();
                case HttpStatusCode.Unauthorized:
                    throw new ESPNAuthenticationException();
                default:
                    return await apiResponse.Content.ReadFromJsonAsync<TAPIResponseType>(_serializerOptions) 
                        ?? throw new Exception("Failed to deserialize result");
            }
        }

        private async Task<List<int>> LoadLeagueYears(ESPNLeagueCredentials credentials)
        {
            int mostRecentYear = await FindMostRecentLeagueYear(credentials);

            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(credentials, mostRecentYear)
                .WithViews(ESPNView.mStatus)
                .Build();

            MStatusResponse response = await SendAPIRequestAsync<MStatusResponse>(request);

            return response.Status.PreviousSeasons;
        }

        private async Task<int> FindMostRecentLeagueYear(ESPNLeagueCredentials credentials)
        {
            int currentYear = DateTime.Now.Year;

            for (int year = currentYear; year >= 1990; year--)
            {
                HttpRequestMessage request = ESPNRequestBuilder.ForLeague(credentials, year)
                    .Build();
                
                try
                {
                    await SendAPIRequestAsync<MStatusResponse>(request);

                    return year;
                }
                catch (ESPNInvalidYearException)
                {
                    continue;
                }
            }

            throw new ESPNNoActiveYearsException();
        }
    }
}
