using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Outputs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries
{
    public sealed record GetESPNLeagueQuery(ESPNLeagueCredentials Credentials) : IRequest<League>
    {
        private sealed class ESPNImportContext
        {
            public Dictionary<int, Player> PlayerLookup { get; }
            public Dictionary<string, FantasyMember> MemberLookup { get; }
            public Dictionary<int, Team> TeamLookup { get; set; } = [];

            public ESPNImportContext(Dictionary<string, FantasyMember> memberLookup, Dictionary<int, Player> playerLookup)
            {
                PlayerLookup = playerLookup;
                MemberLookup = memberLookup;
            }
        }
        
        public sealed class GetESPNLeagueQueryHandler : IRequestHandler<GetESPNLeagueQuery, League>
        {
            private readonly FantasyHOFDBContext _context;
            private readonly IESPNAPIClientBuilder _espnClientBuilder;
            private readonly IESPNLeagueMapper _espnMapper;

            private ESPNImportContext _importContext = null!;
            
            public GetESPNLeagueQueryHandler(FantasyHOFDBContext context, IESPNAPIClientBuilder espnClientBuilder, IESPNLeagueMapper espnMapper)
            {
                _context = context;
                _espnClientBuilder = espnClientBuilder;
                _espnMapper = espnMapper;
            }

            public async Task<League> Handle(GetESPNLeagueQuery request, CancellationToken cancellationToken)
            {
                ESPNAPIClient espnClient = _espnClientBuilder.Build(request.Credentials);

                List<ESPNSeasonalLeagueData> memberDetails = await espnClient.LoadSeasonalLeagueData();
                List<ESPNWeeklyLeagueData> matchupDetails = await espnClient.LoadWeeklyLeagueData();

                await PrepareImportContextAsync(memberDetails, matchupDetails, cancellationToken);

                League league = CreateLeague(request.Credentials.LeagueId, memberDetails, matchupDetails);

                await SaveNewLeagueData(league, cancellationToken);

                return league; 
            }

            private async Task PrepareImportContextAsync(List<ESPNSeasonalLeagueData> espnMemberDetails, List<ESPNWeeklyLeagueData> espnMatchupDetails, CancellationToken cancellationToken)
            {
                IEnumerable<string> allEspnMemberIds = espnMemberDetails
                    .SelectMany(x => x.Members)
                    .Select(x => x.Id)
                    .Distinct();

                Dictionary<string, FantasyMember> memberLookup = await _context.FantasyMembers
                    .Where(member => member.FantasyProviderId == FantasyProviderId.ESPN && allEspnMemberIds.Contains(member.ProviderMemberId))
                    .ToDictionaryAsync(member => member.ProviderMemberId, cancellationToken);

                IEnumerable<int> allEspnPlayerIds = espnMatchupDetails
                    .SelectMany(espnWeeklyLeagueData => espnWeeklyLeagueData.Matchups)
                    .SelectMany(espnMatchup => new[] { espnMatchup.Home, espnMatchup.Away })
                    .Where(espnTeam => espnTeam is not null)
                    .SelectMany(espnTeam => espnTeam!.rosterForCurrentScoringPeriod.Entries)
                    .Select(espnRosterEntry => espnRosterEntry.PlayerPoolEntry.Player.Id)
                    .Distinct();

                Dictionary<int, Player> playerLookup = await _context.Players
                    .Where(player => player.ProviderId == FantasyProviderId.ESPN && allEspnPlayerIds.Contains(player.ProviderPlayerId))
                    .ToDictionaryAsync(player => player.ProviderPlayerId, cancellationToken);

                _importContext = new(memberLookup, playerLookup);
            }

            private League CreateLeague(string espnLeagueId, List<ESPNSeasonalLeagueData> espnSeasons, List<ESPNWeeklyLeagueData> espnWeeklyData)
            {
                League league = _espnMapper.MapLeague(espnLeagueId);

                foreach (ESPNSeasonalLeagueData espnSeason in espnSeasons)
                {
                    IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData = espnWeeklyData
                        .Where(espnWeek => espnWeek.Year == espnSeason.Year);

                    league.Seasons.Add(CreateLeagueSeason(espnSeason, espnSeasonMatchupData));
                }

                return league;
            }

            private LeagueSeason CreateLeagueSeason(ESPNSeasonalLeagueData espnSeason, IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData)
            {
                LeagueSeason season = _espnMapper.MapLeagueSeason(espnSeason);

                season.Settings = CreateLeagueSeasonSettings(espnSeason.LeagueSettings);
                season.LeagueSeasonMembers = CreateLeagueSeasonMembers(espnSeason.Members, espnSeason.Teams, espnSeasonMatchupData);

                return season;
            }

            private LeagueSeasonSettings CreateLeagueSeasonSettings(ESPNLeagueSettings espnSettings)
            {
                LeagueSeasonSettings settings = _espnMapper.MapLeagueSeasonSettings(espnSettings);

                settings.ScheduleSettings = _espnMapper.MapLeagueSeasonScheduleSettings(espnSettings.ScheduleSettings);
                settings.ScoringSettings = CreateLeagueSeasonScoringSettings(espnSettings.ScoringSettings);

                return settings;
            }

            private LeagueSeasonScoringSettings CreateLeagueSeasonScoringSettings(ESPNScoringSettings espnScoringSettings)
            {
                LeagueSeasonScoringSettings scoringSettings = _espnMapper.MapLeagueSeasonScoringSettings(espnScoringSettings);

                scoringSettings.ScoringItems = CreateScoringItems(espnScoringSettings.ScoringItems);

                return scoringSettings;
            }

            private List<LeagueSeasonScoringItem> CreateScoringItems(List<ESPNScoringItem> espnScoringItems)
            {
                List<LeagueSeasonScoringItem> scoringItems = [];

                foreach (ESPNScoringItem scoringItem in espnScoringItems)
                {
                    scoringItems.Add(_espnMapper.MapLeagueSeasonScoringItem(scoringItem));
                }

                return scoringItems;
            }

            private List<LeagueSeasonMember> CreateLeagueSeasonMembers(List<ESPNFantasyMember> espnMembers, List<ESPNFantasyTeam> espnTeams, IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData)
            {
                List<LeagueSeasonMember> leagueSeasonMembers = [];

                _importContext.TeamLookup.Clear();

                foreach (ESPNFantasyTeam espnTeam in espnTeams)
                {
                    _importContext.TeamLookup.TryAdd(espnTeam.Id, CreateTeam(espnTeam));
                }

                foreach (ESPNFantasyMember espnMember in espnMembers)
                {
                    LeagueSeasonMember leagueSeasonMember = _espnMapper.MapLeagueSeasonMember(espnMember);

                    leagueSeasonMember.Member = GetOrCreateFantasyMember(espnMember);
                    leagueSeasonMember.LeagueSeasonMemberTeams = CreateLeagueSeasonMemberTeams(espnMember, espnTeams, espnSeasonMatchupData);

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

            private FantasyMember GetOrCreateFantasyMember(ESPNFantasyMember espnMember)
            {
                _importContext.MemberLookup.TryGetValue(espnMember.Id, out FantasyMember? existingMember);

                if (existingMember is not null) return existingMember;

                FantasyMember newMember = _espnMapper.MapFantasyMember(espnMember);

                _importContext.MemberLookup.Add(espnMember.Id, newMember);

                return newMember;
            }

            private List<LeagueSeasonMemberTeam> CreateLeagueSeasonMemberTeams(
                ESPNFantasyMember espnMember, 
                List<ESPNFantasyTeam> espnTeams, 
                IEnumerable<ESPNWeeklyLeagueData> espnSeasonMatchupData 
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

                    leagueSeasonMemberTeam.Team = _importContext.TeamLookup[espnTeam.Id];
                    leagueSeasonMemberTeam.Team.Matchups = CreateTeamMatchups(espnTeam.Id, espnTeamMatchups);

                    leagueSeasonMemberTeams.Add(leagueSeasonMemberTeam);
                }

                return leagueSeasonMemberTeams;
            }

            private List<TeamMatchup> CreateTeamMatchups(int espnTeamId, IEnumerable<ESPNWeeklyLeagueData> espnTeamMatchups)
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
                        matchup.Opponent = _importContext.TeamLookup[opponentTeam.TeamId]; 
                    }

                    matchup.MatchupRosterSpots = CreateMatchupRosterSpots(primaryTeam.rosterForCurrentScoringPeriod);
                    
                    teamMatchups.Add(matchup);
                }

                return teamMatchups;
            }

            private List<MatchupRosterSpot> CreateMatchupRosterSpots(ESPNRoster espnRoster)
            {
                List<MatchupRosterSpot> matchupRosterSpots = [];

                foreach (ESPNRosterSpot espnRosterSpot in espnRoster.Entries)
                {
                    MatchupRosterSpot rosterSpot = _espnMapper.MapMatchupRosterSpot(espnRosterSpot);

                    rosterSpot.Player = GetOrCreatePlayer(espnRosterSpot.PlayerPoolEntry.Player);
                    rosterSpot.AccumulatedStats = CreateAccumulatedStats(espnRosterSpot.PlayerPoolEntry.Player);

                    matchupRosterSpots.Add(rosterSpot);
                }

                return matchupRosterSpots;
            }

            private Player GetOrCreatePlayer(ESPNPlayer espnPlayer)
            {
                _importContext.PlayerLookup.TryGetValue(espnPlayer.Id, out Player? existingPlayer);

                if (existingPlayer is not null) return existingPlayer;

                Player newPlayer = _espnMapper.MapPlayer(espnPlayer);

                _importContext.PlayerLookup.Add(espnPlayer.Id, newPlayer);

                return newPlayer;
            }

            private List<AccumulatedStat> CreateAccumulatedStats(ESPNPlayer player)
            {
                List<AccumulatedStat> accumulatedStats = [];

                ESPNPlayerStatProfile? espnLeagueAdjustedStats = player.Stats.FirstOrDefault(espnStatProfile => espnStatProfile.StatSourceId == 0);

                if (espnLeagueAdjustedStats is null) return accumulatedStats;

                foreach (int statId in espnLeagueAdjustedStats.AppliedStats.Keys)
                {
                    AccumulatedStat accumulatedStat = _espnMapper.MapAccumulatedStat(
                        statId, 
                        espnLeagueAdjustedStats.AppliedStats[statId], 
                        espnLeagueAdjustedStats.Stats[statId]);

                    accumulatedStats.Add(accumulatedStat);
                }

                return accumulatedStats;
            }

            private async Task SaveNewLeagueData(League league, CancellationToken cancellationToken)
            {
                await using IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
                
                await DeleteLeagueIfExists(league.ProviderLeagueId, cancellationToken);

                _context.Leagues.Add(league);
                await _context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
            }

            private async Task DeleteLeagueIfExists(string espnLeagueId, CancellationToken cancellationToken)
            {
                League? existingLeague = await _context.Leagues.FirstOrDefaultAsync(league =>
                    league.FantasyProviderId == FantasyProviderId.ESPN &&
                    league.ProviderLeagueId == espnLeagueId,
                    cancellationToken);

                if (existingLeague is null) return;

                _context.Leagues.Remove(existingLeague);
            }
        }
    }
}
