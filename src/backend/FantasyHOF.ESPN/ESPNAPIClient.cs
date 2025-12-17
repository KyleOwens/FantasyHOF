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
        public Task<IEnumerable<ESPNSeasonalLeagueData>> LoadSeasonalLeagueData();
        public Task<IEnumerable<ESPNWeeklyLeagueData>> LoadWeeklyLeagueData();
    }

    public class ESPNAPIClient : IESPNAPIClient
    {
        private readonly HttpClient _client;
        private readonly ESPNLeagueCredentials _credentials;
        private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNameCaseInsensitive = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

        private List<int>? _leagueYearCache;

        public ESPNAPIClient(HttpClient client, ESPNLeagueCredentials credentials)
        {
            _client = client;
            _credentials = credentials;

            if (!_client.DefaultRequestHeaders.Accept.Any(h => h.MediaType == "application/json"))
            {
                _client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }

        private async Task<TAPIResponseType> SendAPIRequestAsync<TAPIResponseType>(HttpRequestMessage request)
        {
            bool expectsOneResult = request.RequestUri?.AbsoluteUri.Contains("seasonId") == true;

            HttpResponseMessage apiResponse = await _client.SendAsync(request);

            switch (apiResponse.StatusCode)
            {
                case HttpStatusCode.BadRequest:
                    throw new ESPNLeagueInvalidException();
                case HttpStatusCode.NotFound:
                    throw new ESPNInvalidYearException();
                case HttpStatusCode.Unauthorized:
                    throw new ESPNAuthenticationException();
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                throw new ESPNHttpException(apiResponse.StatusCode, await apiResponse.Content.ReadAsStringAsync());
            }

            try
            {
                if (expectsOneResult)
                {
                    IEnumerable<TAPIResponseType> serializationResult = (await apiResponse.Content.ReadFromJsonAsync<IEnumerable<TAPIResponseType>>(_serializerOptions))
                        ?? throw new Exception();

                    return serializationResult.First();
                }
                else
                {
                    return await apiResponse.Content.ReadFromJsonAsync<TAPIResponseType>(_serializerOptions)
                        ?? throw new Exception();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to deserialize result: {request.RequestUri} \n {ex.Message}");
            }
        }

        public async Task<IEnumerable<ESPNSeasonalLeagueData>> LoadSeasonalLeagueData()
        {
            IEnumerable<int> leagueYears = await LoadLeagueYears();

            IEnumerable<Task<LeagueDataResponse>> seasonRequestTasks = leagueYears.Select(SendSeasonalLeagueDataRequest);

            return (await Task.WhenAll(seasonRequestTasks))
                .Select(leagueResponse => new ESPNSeasonalLeagueData
                (
                    leagueResponse.SeasonId,
                    leagueResponse.Settings,
                    leagueResponse.Members,
                    leagueResponse.Teams
                ));
        }

        private Task<LeagueDataResponse> SendSeasonalLeagueDataRequest(int year)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                .WithViews(ESPNView.mNav, ESPNView.mTeam, ESPNView.mSettings)
                .Build();

            return SendAPIRequestAsync<LeagueDataResponse>(request);
        }

        public async Task<IEnumerable<ESPNWeeklyLeagueData>> LoadWeeklyLeagueData()
        {
            List<ESPNWeeklyLeagueData> weeklyLeagueData = [];

            IEnumerable<int> leagueYears = await LoadLeagueYears();

            IEnumerable<Task<IEnumerable<ESPNWeeklyLeagueData>>> weeklyDataByYearTasks = leagueYears.Select(SendWeeklyDataRequestsForYear);

            IEnumerable<ESPNWeeklyLeagueData> allLeagueWeeklyData = (await Task.WhenAll(weeklyDataByYearTasks)).SelectMany(weeklyDataByYear => weeklyDataByYear);

            return allLeagueWeeklyData;
        }

        public async Task<IEnumerable<ESPNWeeklyLeagueData>> SendWeeklyDataRequestsForYear(int year)
        {
            ESPNWeeklyStatus matchupWeeks = await LoadSeasonMatchupWeeks(year);

            int lastWeek = year == DateTime.Now.Year ? 
                matchupWeeks.CurrentMatchupPeriod - 1 : 
                matchupWeeks.CurrentMatchupPeriod;

            List<Task<WeeklyDataResponse>> matchupTasks = [];
            for (int week = matchupWeeks.FirstScoringPeriod; week <= lastWeek; week++)
            {
                matchupTasks.Add(SendWeeklyDataRequest(year, week));
            }

            return (await Task.WhenAll(matchupTasks))
                .Where(weeklyResponse => weeklyResponse.Schedule.Count > 0)
                .Select(weeklyResponse => new ESPNWeeklyLeagueData()
                {
                    Year = weeklyResponse.SeasonId,
                    Week = weeklyResponse.Schedule.First().MatchupPeriodId,
                    Matchups = weeklyResponse.Schedule
                });
        }

        private async Task<ESPNWeeklyStatus> LoadSeasonMatchupWeeks(int year)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                .WithViews(ESPNView.mBoxscore)
                .Build();

            return (await SendAPIRequestAsync<WeeklyStatusResponse>(request)).Status;
        }

        public Task<WeeklyDataResponse> SendWeeklyDataRequest(int year, int week)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, year)
                .WithScoringPeriod(week)
                .WithViews(ESPNView.mBoxscore)
                .Build();

            return SendAPIRequestAsync<WeeklyDataResponse>(request);
        }

        private async Task<List<int>> LoadLeagueYears()
        {
            if (_leagueYearCache is not null) return _leagueYearCache;

            List<int> leagueYears = await GetPreviousLeagueYears();

            if (await HasActiveLeagueYear())
            {
                leagueYears.Add(DateTime.Now.Year);
            }

            if (leagueYears.Count == 0) throw new ESPNNoActiveYearsException();

            _leagueYearCache = leagueYears;

            return _leagueYearCache;
        }

        private async Task<List<int>> GetPreviousLeagueYears()
        {
            List<int> leagueYears = [];

            HttpRequestMessage previousYearsRequest = ESPNRequestBuilder.ForLeague(_credentials)
                .WithViews(ESPNView.mStatus)
                .Build();

            PreviousYearsResponse mostRecentPreviousYear = (await SendAPIRequestAsync<List<PreviousYearsResponse>>(previousYearsRequest))
                .OrderBy(year => year.SeasonId)
                .Last();

            leagueYears.AddRange(mostRecentPreviousYear.Status.PreviousSeasons);
            leagueYears.Add(mostRecentPreviousYear.SeasonId);

            return leagueYears;
        }

        private async Task<bool> HasActiveLeagueYear()
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials, DateTime.Now.Year)
                .Build();

            try
            {
                await SendAPIRequestAsync<PreviousYearsResponse>(request);

                return true;
            }
            catch (ESPNInvalidYearException)
            {
                return false;
            }
        }
    }
}
