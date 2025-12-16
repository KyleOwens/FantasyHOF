using FantasyHOF.ESPN.Errors;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Outputs;
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
    public interface IESPNAPIClient
    {
        public Task<List<ESPNSeasonalLeagueData>> LoadSeasonalLeagueData();
    }

    public class ESPNAPIClient : IESPNAPIClient
    {
        private readonly HttpClient _client;
        private readonly ESPNLeagueCredentials _credentials;
        private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        private List<int>? _leagueYearCache;
        private int? _mostRecentYearCache;

        public ESPNAPIClient(HttpClient client, ESPNLeagueCredentials credentials)
        {
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            _client = client;
            _credentials = credentials;
        }

        private async Task<TAPIResponseType> SendAPIRequestAsync<TAPIResponseType>(HttpRequestMessage request)
        {
            HttpResponseMessage apiResponse = await _client.SendAsync(request);

            switch (apiResponse.StatusCode)
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

        public async Task<List<ESPNSeasonalLeagueData>> LoadSeasonalLeagueData()
        {
            IEnumerable<int> leagueYears = await LoadLeagueYears();

            List<ESPNSeasonalLeagueData> seasonalLeagueData = new();

            foreach (int year in leagueYears)
            {
                HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                    .WithViews(ESPNView.mNav, ESPNView.mTeam, ESPNView.mSettings)
                    .Build();

                LeagueDataResposne response = await SendAPIRequestAsync<LeagueDataResposne>(request);

                seasonalLeagueData.Add(new ESPNSeasonalLeagueData(year, response.Settings, response.Members, response.Teams));
            }

            return seasonalLeagueData;
        }

        public async Task<List<ESPNWeeklyLeagueData>> LoadWeeklyLeagueData()
        {
            IEnumerable<int> leagueYears = await LoadLeagueYears();

            List<ESPNWeeklyLeagueData> weeklyLeagueData = new();

            foreach (int year in leagueYears)
            {
                ESPNWeeklyStatus matchupWeeks = (await LoadMatchupWeeks(year)).Status;

                int lastWeek = year == DateTime.Now.Year ? matchupWeeks.CurrentMatchupPeriod - 1 : matchupWeeks.CurrentMatchupPeriod;

                for (int matchupWeek = matchupWeeks.FirstScoringPeriod; matchupWeek <= lastWeek; matchupWeek++)
                {
                    WeeklyDataResponse matchupData = await LoadMatchup(year, matchupWeek);

                    weeklyLeagueData.Add(new ESPNWeeklyLeagueData() { 
                        Year = year,
                        Week = matchupWeek,
                        Matchups = matchupData.Schedule 
                    });
                }
            }

            return weeklyLeagueData;
        }

        private async Task<List<int>> LoadLeagueYears()
        {
            if (_leagueYearCache is not null) return _leagueYearCache;

            int mostRecentYear = await FindMostRecentLeagueYear();

            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, mostRecentYear)
                .WithViews(ESPNView.mStatus)
                .Build();

            PreviousYearsResponse response = await SendAPIRequestAsync<PreviousYearsResponse>(request);

            _leagueYearCache = response.Status.PreviousSeasons
                .Append(mostRecentYear)
                .Where(year => year >= 2018) // temporary until pre-2018 API is fleshed out
                .ToList();

            return _leagueYearCache;
        }

        private async Task<int> FindMostRecentLeagueYear()
        {
            if (_mostRecentYearCache is not null) return _mostRecentYearCache.Value;
            
            int currentYear = DateTime.Now.Year;

            for (int year = currentYear; year >= 1990; year--)
            {
                HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                    .Build();
                
                try
                {
                    await SendAPIRequestAsync<PreviousYearsResponse>(request);

                    _mostRecentYearCache = year;

                    return year;
                }
                catch (ESPNInvalidYearException)
                {
                    continue;
                }
            }

            throw new ESPNNoActiveYearsException();
        }

        private async Task<WeeklyStatusResponse> LoadMatchupWeeks(int year)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                    .WithViews(ESPNView.mBoxscore)
                    .Build();

            return await SendAPIRequestAsync<WeeklyStatusResponse>(request);
        }

        private async Task<WeeklyDataResponse> LoadMatchup(int year, int week)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                .WithViews(ESPNView.mBoxscore)
                .WithScoringPeriod(week)
                .Build();

            return await SendAPIRequestAsync<WeeklyDataResponse>(request);
        }
    }
}
