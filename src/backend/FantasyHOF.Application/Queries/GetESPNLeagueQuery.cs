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
                await _context.Teams.ExecuteDeleteAsync();
                
                ESPNAPIClient espnClient = _espnClientBuilder.Build(request.Credentials);

                List<ESPNSeasonalLeagueData> memberDetails = await espnClient.LoadSeasonalLeagueData();
                List<ESPNWeeklyLeagueData> matchupDetails = await espnClient.LoadWeeklyLeagueData();

                League league = await CreateLeagueAsync(request.Credentials.LeagueId, memberDetails, matchupDetails);
                
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

            public async Task<League> CreateLeagueAsync(string espnLeagueId, List<ESPNSeasonalLeagueData> espnSeasons, List<ESPNWeeklyLeagueData> espnWeeklyData)
            {
                League league = _espnMapper.MapLeague(espnLeagueId);

                foreach (ESPNSeasonalLeagueData espnSeason in espnSeasons)
                {
                    IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData = espnWeeklyData
                        .Where(espnWeek => espnWeek.Year == espnSeason.Year);

                    league.Seasons.Add(await CreateLeagueSeasonAsync(espnSeason, espnSeasonMatchupData));
                }

                return league;
            }

            public async Task<LeagueSeason> CreateLeagueSeasonAsync(ESPNSeasonalLeagueData espnSeason, IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData)
            {
                LeagueSeason season = _espnMapper.MapLeagueSeason(espnSeason);

                season.Settings = CreateLeagueSeasonSettings(espnSeason.LeagueSettings);
                season.LeagueSeasonMembers = await CreateLeagueSeasonMembersAsync(espnSeason.Members, espnSeason.Teams, espnSeasonMatchupData);

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

            private async Task<List<LeagueSeasonMember>> CreateLeagueSeasonMembersAsync(List<ESPNFantasyMember> espnMembers, List<ESPNFantasyTeam> espnTeams, IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData)
            {
                List<LeagueSeasonMember> leagueSeasonMembers = [];
                Dictionary<int, Team> teamLookup = [];

                foreach (ESPNFantasyTeam espnTeam in espnTeams)
                {
                    teamLookup.Add(espnTeam.Id, CreateTeam(espnTeam));
                }

                foreach (ESPNFantasyMember espnMember in espnMembers)
                {
                    LeagueSeasonMember leagueSeasonMember = _espnMapper.MapLeagueSeasonMember(espnMember);

                    leagueSeasonMember.Member = await GetOrCreateFantasyMemberAsync(espnMember);
                    leagueSeasonMember.LeagueSeasonMemberTeams = CreateLeagueSeasonMemberTeams(espnMember, espnTeams, espnSeasonMatchupData, teamLookup);

                    leagueSeasonMembers.Add(leagueSeasonMember);
                }

                return leagueSeasonMembers;
            }

            private Team CreateTeam(ESPNFantasyTeam espnTeam)
            {
                Team team = _espnMapper.MapTeam(espnTeam);

                team.SeasonStats = _espnMapper.MapTeamSeasonStats(espnTeam.Record.Overall);

                return team;
            }

            private async Task<FantasyMember> GetOrCreateFantasyMemberAsync(ESPNFantasyMember espnMember)
            {
                FantasyMember? existingMember = await _context.FantasyMembers
                    .FirstOrDefaultAsync(member =>
                        member.FantasyProviderId == FantasyProviderId.ESPN &&
                        member.ProviderMemberId == espnMember.Id);

                if (existingMember != null) return existingMember;

                return _espnMapper.MapFantasyMember(espnMember);
            }

            private List<LeagueSeasonMemberTeam> CreateLeagueSeasonMemberTeams(
                ESPNFantasyMember espnMember, 
                List<ESPNFantasyTeam> espnTeams, 
                IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData, 
                Dictionary<int, Team> teamLookup
            )
            {
                List<LeagueSeasonMemberTeam> leagueSeasonMemberTeams = [];

                IEnumerable<ESPNFantasyTeam> espnMemberTeams = espnTeams
                    .Where(espnTeam => espnTeam.Owners.Contains(espnMember.Id));

                foreach (ESPNFantasyTeam espnTeam in espnMemberTeams)
                {
                    LeagueSeasonMemberTeam leagueSeasonMemberTeam = _espnMapper.MapLeagueSeasonMemberTeam();

                    IEnumerable<ESPNWeeklyLeagueData> espnTeamMatchups = espnSeasonMatchupData
                        .Select(espnWeek => new ESPNWeeklyLeagueData()
                        {
                            Year = espnWeek.Year,
                            Week = espnWeek.Week,
                            Matchups = espnWeek.Matchups.Where(espnMatchup =>
                                    espnMatchup.Home?.TeamId == espnTeam.Id ||
                                    espnMatchup.Away?.TeamId == espnTeam.Id).ToList()
                        });

                    leagueSeasonMemberTeam.Team = teamLookup[espnTeam.Id];
                    leagueSeasonMemberTeam.Team.Matchups = CreateTeamMatchups(espnTeam.Id, teamLookup, espnTeamMatchups);

                    leagueSeasonMemberTeams.Add(leagueSeasonMemberTeam);
                }

                return leagueSeasonMemberTeams;
            }

            private List<TeamMatchup> CreateTeamMatchups(int espnTeamId, Dictionary<int, Team> teamLookup, IEnumerable<ESPNWeeklyLeagueData> espnTeamMatchups)
            {
                List<TeamMatchup> teamMatchups = [];

                foreach (ESPNWeeklyLeagueData espnTeamMatchup in espnTeamMatchups)
                {
                    ESPNMatchup espnMatchup = espnTeamMatchup.Matchups.FirstOrDefault()!;

                    ESPNMatchupTeam primaryTeam = espnMatchup.Home?.TeamId == espnTeamId ? espnMatchup.Home! : espnMatchup.Away!;
                    ESPNMatchupTeam? opponentTeam = espnMatchup.Home?.TeamId != espnTeamId ? espnMatchup.Home : espnMatchup.Away;

                    TeamMatchup matchup = _espnMapper.MapTeamMatchup(espnTeamMatchup.Week, primaryTeam);

                    if (opponentTeam is not null) 
                    { 
                        matchup.Opponent = teamLookup[opponentTeam.TeamId]; 
                    }
                    
                    teamMatchups.Add(matchup);
                }

                return teamMatchups;
            }
        }
    }
}
