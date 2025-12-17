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
        public Task<List<ESPNWeeklyLeagueData>> LoadWeeklyLeagueData();
    }

    public class ESPNAPIClient : IESPNAPIClient
    {
        private readonly HttpClient _client;
        private readonly ESPNLeagueCredentials _credentials;
        private static readonly JsonSerializerOptions _serializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

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
                return await apiResponse.Content.ReadFromJsonAsync<TAPIResponseType>(_serializerOptions)
                    ?? throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception($"Failed to deserialize result: {request.RequestUri}");
            }
        }

        public async Task<List<ESPNSeasonalLeagueData>> LoadSeasonalLeagueData()
        {
            List<ESPNSeasonalLeagueData> allSeasonsData = [];

            allSeasonsData.AddRange(await LoadHistoricalSeasonLeagueData());
            
            ESPNSeasonalLeagueData? currentSeasonData = await LoadCurrentSeasonLeagueData();
            if (currentSeasonData is not null)
            {
                allSeasonsData.Add(currentSeasonData);
            }

            return allSeasonsData;
        }

        private async Task<List<ESPNSeasonalLeagueData>> LoadHistoricalSeasonLeagueData()
        {
            List<ESPNSeasonalLeagueData> historicalLeagueData = [];
            
            IEnumerable<int> previousLeagueYears = (await LoadLeagueYears())
                .Where(year => year != DateTime.Now.Year);

            if (!previousLeagueYears.Any()) return historicalLeagueData;

            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials)
                .WithViews(ESPNView.mNav, ESPNView.mTeam, ESPNView.mSettings)
                .Build();

            List<LeagueDataResponse> response = await SendAPIRequestAsync<List<LeagueDataResponse>>(request);

            historicalLeagueData.AddRange(response.Select(leagueDataResponse => new ESPNSeasonalLeagueData(
                leagueDataResponse.SeasonId, 
                leagueDataResponse.Settings, 
                leagueDataResponse.Members, 
                leagueDataResponse.Teams)));

            return historicalLeagueData;
        }

        private async Task<ESPNSeasonalLeagueData?> LoadCurrentSeasonLeagueData()
        {
            if (!(await LoadLeagueYears()).Contains(DateTime.Now.Year)) return null;

            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials)
                .WithViews(ESPNView.mNav, ESPNView.mTeam, ESPNView.mSettings)
                .Build();

            LeagueDataResponse response = await SendAPIRequestAsync<LeagueDataResponse>(request);

            return new ESPNSeasonalLeagueData(response.SeasonId, response.Settings, response.Members, response.Teams);
        }

        public async Task<List<ESPNWeeklyLeagueData>> LoadWeeklyLeagueData()
        {
            List<ESPNWeeklyLeagueData> weeklyLeagueData = [];

            weeklyLeagueData.AddRange(await LoadNonHistoricalWeeklyLeagueData());
            weeklyLeagueData.AddRange(await LoadHistoricalWeeklyLeagueData());

            return weeklyLeagueData;
        }

        private async Task<List<ESPNWeeklyLeagueData>> LoadHistoricalWeeklyLeagueData()
        {
            List<ESPNWeeklyLeagueData> historicalWeeklyData = [];

            bool hasHistoricalYears = (await LoadLeagueYears())
                .Where(year => year < 2018)
                .Any();

            if (!hasHistoricalYears) return historicalWeeklyData;

            IEnumerable<Task<List<ESPNWeeklyLeagueData>>> weeklyLeagueDataTasks = Enumerable.Range(1, 16)
                .Select(LoadHistoricalMatchups);

            IEnumerable<ESPNWeeklyLeagueData> weeklyLeagueData = (await Task.WhenAll(weeklyLeagueDataTasks))
                .SelectMany(weekData => weekData);

            historicalWeeklyData.AddRange(weeklyLeagueData);

            return historicalWeeklyData;
        }

        private async Task<List<ESPNWeeklyLeagueData>> LoadHistoricalMatchups(int matchupWeek)
        {
            List<ESPNWeeklyLeagueData> historicalWeeklyData = [];

            HttpRequestMessage matchupRequest = ESPNRequestBuilder.ForLeague(_credentials)
                .WithViews(ESPNView.mBoxscore)
                .WithScoringPeriod(matchupWeek)
                .Build();

            List<WeeklyDataResponse> matchupWeekResponse = (await SendAPIRequestAsync<List<WeeklyDataResponse>>(matchupRequest))
                .Where(response => response.SeasonId < 2018)
                .Where(response => response.Schedule.Any())
                .ToList();

            historicalWeeklyData.AddRange(matchupWeekResponse.Select(weeklyDataResponse => new ESPNWeeklyLeagueData()
            {
                Year = weeklyDataResponse.SeasonId,
                Week = matchupWeek,
                Matchups = weeklyDataResponse.Schedule
            }));

            return historicalWeeklyData;
        }

        private async Task<List<ESPNWeeklyLeagueData>> LoadNonHistoricalWeeklyLeagueData()
        {
            IEnumerable<int> nonHistoricalLeagueYears = (await LoadLeagueYears())
                .Where(year => year >= 2018);

            List<ESPNWeeklyLeagueData> weeklyLeagueData = [];

            foreach (int year in nonHistoricalLeagueYears)
            {
                ESPNWeeklyStatus matchupWeeks = (await LoadNonHistoricalMatchupWeeks(year)).Status;

                int lastWeek = year == DateTime.Now.Year ? matchupWeeks.CurrentMatchupPeriod - 1 : matchupWeeks.CurrentMatchupPeriod;

                IEnumerable<Task<WeeklyDataResponse>> matchupTasks = Enumerable.Range(matchupWeeks.FirstScoringPeriod, lastWeek - matchupWeeks.FirstScoringPeriod + 1)
                    .Select(matchupWeek => LoadMatchup(year, matchupWeek));

                IEnumerable<WeeklyDataResponse> weeklyResponses = await Task.WhenAll(matchupTasks);

                foreach (WeeklyDataResponse matchupData in weeklyResponses)
                {
                    weeklyLeagueData.Add(new ESPNWeeklyLeagueData()
                    {
                        Year = year,
                        Week = matchupData.Schedule.First().MatchupPeriodId,
                        Matchups = matchupData.Schedule
                    });
                }
            }

            return weeklyLeagueData;
        }

        private async Task<WeeklyStatusResponse> LoadNonHistoricalMatchupWeeks(int year)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials)
                .ForYear(year)
                .WithViews(ESPNView.mBoxscore)
                .Build();

            return await SendAPIRequestAsync<WeeklyStatusResponse>(request);
        }

        private async Task<WeeklyDataResponse> LoadMatchup(int year, int week)
        {
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials)
                .ForYear(year)
                .WithViews(ESPNView.mBoxscore)
                .WithScoringPeriod(week)
                .Build();

            return await SendAPIRequestAsync<WeeklyDataResponse>(request);
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
            HttpRequestMessage request = ESPNRequestBuilder.ForLeague(_credentials)
                .ForYear(DateTime.Now.Year)
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
