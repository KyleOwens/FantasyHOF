using FantasyHOF.ESPN.Types.Headers;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.ESPN
{
    public enum ESPNView
    {
        mStatus,
        mSettings,
        mRoster,
        mMatchup,
        mSchedule,
        mTeam,
        mNav,
        mBoxscore,
        mMatchupScore,
    }
    
    public class ESPNRequestBuilder
    {
        private readonly ESPNLeagueCredentials _credentials;
        private readonly List<ESPNView> _views = [];

        private int? _requestYear;
        private int? _scoringPeriod;

        private bool IsLegacyRequest => _requestYear is null || _requestYear < 2018;

        private string BaseURL => IsLegacyRequest ?
            "https://lm-api-reads.fantasy.espn.com/apis/v3/games/ffl/leagueHistory/" :
            "https://lm-api-reads.fantasy.espn.com/apis/v3/games/ffl/seasons/";

        private string RequestURI => IsLegacyRequest ?
            $"{BaseURL}{_credentials.LeagueId}" :
            $"{BaseURL}{_requestYear}/segments/0/leagues/{_credentials.LeagueId}";
            
        private ESPNRequestBuilder(ESPNLeagueCredentials credentials, int? requestYear)
        {
            _credentials = credentials;
            _requestYear = requestYear;
        }

        public static ESPNRequestBuilder ForLeague(ESPNLeagueCredentials credentials, int? year = null)
        {
            return new(credentials, year);
        }

        public ESPNRequestBuilder WithViews(params ESPNView[] views)
        {
            _views.AddRange(views);

            return this;
        }

        public ESPNRequestBuilder WithScoringPeriod(int scoringPeriod)
        {
            _scoringPeriod = scoringPeriod;

            return this;
        }

        public HttpRequestMessage Build()
        {
            UriBuilder uriBuilder = new(RequestURI);

            AddQueryParameters(uriBuilder);

            HttpRequestMessage request = new(HttpMethod.Get, uriBuilder.Uri);

            AddHeaders(request);

            return request;
        }

        private void AddQueryParameters(UriBuilder uriBuilder)
        {   
            AddViewParams(uriBuilder);
            AddFilterParams(uriBuilder);
            AddLegacyParams(uriBuilder);
        }

        private void AddLegacyParams(UriBuilder uriBuilder)
        {
            if (!IsLegacyRequest) return;
            if (_requestYear is null) return;

            uriBuilder.AddQueryParameter("seasonId", _requestYear.Value.ToString());
        }

        private void AddFilterParams(UriBuilder uriBuilder)
        {
            if (_scoringPeriod.HasValue)
            {
                uriBuilder.AddQueryParameter("scoringPeriodId", _scoringPeriod.Value.ToString());
            }
        }

        private void AddViewParams(UriBuilder uriBuilder)
        {
            foreach (ESPNView view in _views)
            {
                uriBuilder.AddQueryParameter("view", view.ToString());
            }
        }

        private void AddHeaders(HttpRequestMessage request)
        {
            AddCredentialHeaders(request);
            AddFilterHeaders(request);
        }

        private void AddCredentialHeaders(HttpRequestMessage request)
        {
            if (_credentials.IsPrivateLeague)
            {
                request.Headers.Add("Cookie", $"SWID={_credentials.SWID};espn_s2={_credentials.ESPNS2Id}");
            }
        }

        private void AddFilterHeaders(HttpRequestMessage request)
        {
            if (_scoringPeriod.HasValue)
            {
                request.Headers.Add("X-Fantasy-Filter", new ESPNFantasyFilterHeader(_scoringPeriod.Value).ToString());
            }
        }
    }
}
