using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Outputs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries
{
    public sealed record GetESPNLeagueQuery(ESPNLeagueCredentials Credentials) : IRequest<League>
    {
        public sealed class GetESPNLeagueQueryHandler : IRequestHandler<GetESPNLeagueQuery, League>
        {
            private readonly FantasyHOFDBContext _context;
            private readonly IESPNAPIClientBuilder _espnClientBuilder;
            private readonly IESPNLeagueMapper _espnMapper;
            

            public GetESPNLeagueQueryHandler(FantasyHOFDBContext context, IESPNAPIClientBuilder espnClientBuilder, IESPNLeagueMapper espnMapper)
            {
                _context = context;
                _espnClientBuilder = espnClientBuilder;
                _espnMapper = espnMapper;
            }

            public async Task<League> Handle(GetESPNLeagueQuery request, CancellationToken cancellationToken)
            {
                await _context.Leagues.ExecuteDeleteAsync();
                
                ESPNAPIClient espnClient = _espnClientBuilder.Build(request.Credentials);

                List<ESPNSeasonalLeagueData> memberDetails = await espnClient.LoadSeasonalLeagueData();
                List<ESPNWeeklyLeagueData> matchupDetails = await espnClient.LoadWeeklyLeagueData();

                League league = CreateLeague(request.Credentials.LeagueId, memberDetails, matchupDetails);
                
                try
                {
                    _context.Leagues.Add(league);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

                return league; 
            }

            public League CreateLeague(string espnLeagueId, List<ESPNSeasonalLeagueData> espnSeasons, List<ESPNWeeklyLeagueData> weeklyLeagueData)
            {
                League league = _espnMapper.MapLeague(espnLeagueId);

                foreach (ESPNSeasonalLeagueData espnSeason in espnSeasons)
                {
                    league.Seasons.Add(CreateLeagueSeason(espnSeason));
                }

                return league;
            }

            public LeagueSeason CreateLeagueSeason(ESPNSeasonalLeagueData espnSeason)
            {
                LeagueSeason season = _espnMapper.MapLeagueSeason(espnSeason);

                LeagueSeasonSettings leagueSeasonSettings = CreateLeagueSeasonSettings(espnSeason.LeagueSettings);

                season.Settings = leagueSeasonSettings;

                return season;
            }

            public LeagueSeasonSettings CreateLeagueSeasonSettings(ESPNLeagueSettings espnSettings)
            {
                LeagueSeasonSettings settings = _espnMapper.MapLeagueSeasonSettings(espnSettings);

                settings.ScheduleSettings = _espnMapper.MapLeagueSeasonScheduleSettings(espnSettings.ScheduleSettings);
                settings.ScoringSettings = CreateLeagueSeasonScoringSettings(espnSettings.ScoringSettings);

                return settings;
            }

            public LeagueSeasonScoringSettings CreateLeagueSeasonScoringSettings(ESPNScoringSettings espnScoringSettings)
            {
                LeagueSeasonScoringSettings scoringSettings = _espnMapper.MapLeagueSeasonScoringSettings(espnScoringSettings);

                scoringSettings.ScoringItems = CreateScoringItems(espnScoringSettings.ScoringItems);

                return scoringSettings;
            }

            public List<LeagueSeasonScoringItem> CreateScoringItems(List<ESPNScoringItem> espnScoringItems)
            {
                List<LeagueSeasonScoringItem> scoringItems = [];

                foreach (ESPNScoringItem scoringItem in espnScoringItems)
                {
                    scoringItems.Add(_espnMapper.MapLeagueSeasonScoringItem(scoringItem));
                }

                return scoringItems;
            }
        }
    }
}
