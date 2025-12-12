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

                var league = _espnMapper.MapLeague(request.Credentials.LeagueId);

                foreach (ESPNSeasonalLeagueData seasonData in memberDetails)
                {
                    var leagueSeason = _espnMapper.MapLeagueSeason(seasonData);
                    var leagueSeasonSettings = _espnMapper.MapLeagueSeasonSettings(seasonData.LeagueSettings);
                    var leagueSeasonScheduleSettings = _espnMapper.MapLeagueSeasonScheduleSettings(seasonData.LeagueSettings.ScheduleSettings);
                    var leagueSeasonScoringSettings = _espnMapper.MapLeagueSeasonScoringSettings(seasonData.LeagueSettings.ScoringSettings);

                    List<LeagueSeasonScoringItem> scoringItems = [];
                    foreach (ESPNScoringItem scoringItem in seasonData.LeagueSettings.ScoringSettings.ScoringItems)
                    {
                        scoringItems.Add(_espnMapper.MapLeagueSeasonScoringItem(scoringItem));
                    }

                    leagueSeasonScoringSettings.ScoringItems = scoringItems;
                    leagueSeasonSettings.ScheduleSettings = leagueSeasonScheduleSettings;
                    leagueSeasonSettings.ScoringSettings = leagueSeasonScoringSettings;
                    leagueSeason.Settings = leagueSeasonSettings;
                    league.Seasons.Add(leagueSeason);
                }
                

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
        }
    }
}
