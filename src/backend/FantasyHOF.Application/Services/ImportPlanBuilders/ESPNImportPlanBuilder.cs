using FantasyHOF.Application.Services.Events;
using FantasyHOF.Application.Services.Mappers;
using FantasyHOF.Application.Types.Services;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Outputs;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Services.ImportPlanBuilders
{
    public interface IESPNImportPlanBuilder
    {
        public Task<LeagueImportPlan> BuildNewLeague(
            string espnLeagueId,
            Guid userId,
            LeagueImport import,
            IEnumerable<ESPNSeasonalLeagueData> espnSeasonalData,
            IEnumerable<ESPNWeeklyLeagueData> weeklyLeagueData,
            CancellationToken ct);
    }

    public class ESPNImportPlanBuilder(
        FantasyHOFDBContext database,
        IESPNLeagueMapper espnMapper,
        ILeagueImportEventSender eventSender
    ) : IESPNImportPlanBuilder
    {
        private Dictionary<string, FantasyMember> _membersByProviderId = [];
        private Dictionary<int, Player> _playersByProviderPlayerId = [];
        private readonly Dictionary<string, LeagueMember> _leagueMembersByProviderId = [];
        private readonly Dictionary<int, LeagueSeason> _leagueSeasonsByYear = [];
        private readonly Dictionary<int, LeagueSeasonSettings> _leagueSeasonSettingsByYear = [];
        private readonly Dictionary<int, LeagueSeasonScheduleSettings> _leagueSeasonScheduleSettingsByYear = [];
        private readonly Dictionary<int, LeagueSeasonScoringSettings> _leagueSeasonScoringSettingsByYear = [];
        private readonly Dictionary<int, List<LeagueSeasonScoringItem>> _leagueSeasonScoringItemsByYear = [];
        private readonly Dictionary<int, List<LeagueSeasonMember>> _leagueSeasonMembersByYear = [];
        private readonly Dictionary<(string espnMemberId, int year), List<LeagueSeasonMemberTeam>> _leagueSeasonMemberTeamsLookup = [];
        private readonly Dictionary<(int year, int espnTeamId), Team> _teamsLookup = [];
        private readonly Dictionary<(int year, int espnTeamId), TeamSeasonStats> _teamSeasonStatsLookup = [];
        private readonly Dictionary<(int year, int espnTeamId), List<TeamMatchup>> _teamMatchupLookup = [];
        private readonly Dictionary<(int year, int week, int espnTeamId), MatchupTeamDetails> _matchupTeamDetailsLookup = [];
        private readonly Dictionary<(int year, int week, int espnTeamId), List<MatchupRosterSpot>> _matchupRosterSpotsLookup = [];
        private readonly Dictionary<(int year, int week, int espnTeamId, int playerId), List<AccumulatedStat>> _accumulatedStatsLookup = [];

        private readonly List<Player> _newPlayers = [];
        private readonly List<FantasyMember> _newMembers = [];

        public async Task<LeagueImportPlan> BuildNewLeague(
            string espnLeagueId,
            Guid userId,
            LeagueImport import,
            IEnumerable<ESPNSeasonalLeagueData> espnSeasonalData,
            IEnumerable<ESPNWeeklyLeagueData> espnWeeklyData,
            CancellationToken ct)
        {
            ResetBuilder();

            await CreateMembers(espnSeasonalData, ct);
            await CreatePlayers(espnWeeklyData, ct);

            CreateLeagueMembers(espnSeasonalData);
            ProcessLeagueSeasons(espnSeasonalData, espnWeeklyData);

            League league = espnMapper.MapLeague(
                espnLeagueId,
                [.. _leagueSeasonsByYear.Values],
                [.. _leagueSeasonSettingsByYear.Values]
            );
            league.UserId = userId;

            return BuildFlattenedLeagueGraph(league);
        }

        private void ResetBuilder()
        {
            _membersByProviderId = [];
            _playersByProviderPlayerId = [];
            _leagueMembersByProviderId.Clear();
            _leagueSeasonsByYear.Clear();
            _leagueSeasonSettingsByYear.Clear();
            _leagueSeasonScheduleSettingsByYear.Clear();
            _leagueSeasonScoringSettingsByYear.Clear();
            _leagueSeasonScoringItemsByYear.Clear();
            _leagueSeasonMembersByYear.Clear();
            _leagueSeasonMemberTeamsLookup.Clear();
            _teamsLookup.Clear();
            _teamSeasonStatsLookup.Clear();
            _teamMatchupLookup.Clear();
            _matchupTeamDetailsLookup.Clear();
            _matchupRosterSpotsLookup.Clear();
            _accumulatedStatsLookup.Clear();

            _newMembers.Clear();
            _newPlayers.Clear();
        }

        private async Task CreateMembers(IEnumerable<ESPNSeasonalLeagueData> espnSeasonalData, CancellationToken ct)
        {
            IEnumerable<ESPNFantasyMember> allEspnMembers = espnSeasonalData
                    .SelectMany(x => x.Members)
                    .DistinctBy(x => x.Id);

            HashSet<string> allEspnMemberIds = [.. allEspnMembers.Select(x => x.Id)];

            _membersByProviderId = await database.FantasyMembers
                    .Where(member => member.FantasyProviderId == FantasyProviderId.ESPN && allEspnMemberIds.Contains(member.ProviderMemberId))
                    .ToDictionaryAsync(member => member.ProviderMemberId, ct);

            foreach (ESPNFantasyMember espnMember in allEspnMembers)
            {
                if (!_membersByProviderId.TryGetValue(espnMember.Id, out FantasyMember? member))
                {
                    member = espnMapper.MapFantasyMember(espnMember);

                    _membersByProviderId.Add(espnMember.Id, member);
                    _newMembers.Add(member);
                }
            }
        }

        private async Task CreatePlayers(IEnumerable<ESPNWeeklyLeagueData> espnWeeklyData, CancellationToken ct)
        {
            IEnumerable<ESPNPlayer> allEspnPlayers = espnWeeklyData
                    .SelectMany(espnWeeklyLeagueData => espnWeeklyLeagueData.Matchups)
                    .SelectMany(espnMatchup => new[] { espnMatchup.Home, espnMatchup.Away })
                    .Where(espnTeam => espnTeam is not null && espnTeam.Roster is not null)
                    .SelectMany(espnTeam => espnTeam!.Roster!.Entries)
                    .Select(espnRosterEntry => espnRosterEntry.PlayerPoolEntry.Player)
                    .DistinctBy(x => x.Id);

            HashSet<int> allEspnPlayerIds = [.. allEspnPlayers.Select(x => x.Id)];

            _playersByProviderPlayerId = await database.Players
                    .Where(player => player.ProviderId == FantasyProviderId.ESPN && allEspnPlayerIds.Contains(player.ProviderPlayerId))
                    .ToDictionaryAsync(player => player.ProviderPlayerId, ct);

            foreach (ESPNPlayer espnPlayer in allEspnPlayers)
            {
                if (!_playersByProviderPlayerId.TryGetValue(espnPlayer.Id, out Player? player))
                {
                    player = espnMapper.MapPlayer(espnPlayer);

                    _playersByProviderPlayerId.Add(espnPlayer.Id, player);
                    _newPlayers.Add(player);
                }
            }
        }

        private void CreateLeagueMembers(IEnumerable<ESPNSeasonalLeagueData> espnSeasonalData)
        {
            ILookup<string, ESPNSeasonalLeagueData> seasonsByESPNMemberId = espnSeasonalData
                .SelectMany(season => season.Members.Select(member => new
                {
                    ESPNMemberId = member.Id,
                    ESPNSeason = season
                }))
                .ToLookup(x => x.ESPNMemberId, x => x.ESPNSeason);

            foreach (string espnMemberId in _membersByProviderId.Keys)
            {
                _leagueMembersByProviderId.TryAdd(
                    espnMemberId,
                    espnMapper.MapLeagueMember(espnMemberId, seasonsByESPNMemberId[espnMemberId])
                );
            }
        }

        private void ProcessLeagueSeasons(IEnumerable<ESPNSeasonalLeagueData> espnSeasonalData, IEnumerable<ESPNWeeklyLeagueData> espnWeeklyData)
        {
            ILookup<int, ESPNWeeklyLeagueData> espnWeeklyDataByYear = espnWeeklyData.ToLookup(x => x.Year);

            foreach (ESPNSeasonalLeagueData espnSeason in espnSeasonalData)
            {
                CreateLeagueSeason(espnSeason);

                ProcessLeagueSeasonSettings(espnSeason.LeagueSettings, espnSeason.Year);
                ProcessLeagueSeasonMembers(
                    espnSeason.Members,
                    espnSeason.Teams,
                    espnSeason.Year
                );

                // We do this here because it is possible for teams to be orphaned and not have owners. if we go through
                // season members/season member teams we can miss teams
                ProcessAllTeams(espnSeason.Teams, espnSeason.Year, espnWeeklyDataByYear[espnSeason.Year]);
            }
        }

        private void ProcessAllTeams(IEnumerable<ESPNFantasyTeam> espnTeams, int year, IEnumerable<ESPNWeeklyLeagueData> espnSeasonWeeklyData)
        {
            ILookup<int, ESPNMatchup> espnMatchupsByESPNTeamId = espnSeasonWeeklyData
              .SelectMany(week => week.Matchups)
              .SelectMany(matchup => new[]
              {
                    new { matchup.Home?.TeamId, Matchup = matchup},
                    new { matchup.Away?.TeamId, Matchup = matchup}
              })
              .Where(x => x.TeamId != null)
              .ToLookup(x => x.TeamId!.Value, x => x.Matchup);

            foreach (ESPNFantasyTeam espnTeam in espnTeams)
            {
                ProcessTeam(espnTeam, espnMatchupsByESPNTeamId[espnTeam.Id], year);
            }
        }

        private void CreateLeagueSeason(ESPNSeasonalLeagueData espnSeason)
        {
            _leagueSeasonsByYear.TryAdd(espnSeason.Year, espnMapper.MapLeagueSeason(espnSeason));
        }

        private void ProcessLeagueSeasonSettings(ESPNLeagueSettings espnSettings, int year)
        {
            CreateLeagueSeasonSettings(espnSettings, year);
            CreateLeagueSeasonScheduleSettings(espnSettings.ScheduleSettings, year);

            ProcessLeagueSeasonScoringSettings(espnSettings.ScoringSettings, year);
        }

        private void CreateLeagueSeasonSettings(ESPNLeagueSettings espnSettings, int year)
        {
            _leagueSeasonSettingsByYear.TryAdd(
                year,
                espnMapper.MapLeagueSeasonSettings(espnSettings)
            );
        }

        private void CreateLeagueSeasonScheduleSettings(ESPNScheduleSettings espnScheduleSettings, int year)
        {
            _leagueSeasonScheduleSettingsByYear.TryAdd(
                year,
                espnMapper.MapLeagueSeasonScheduleSettings(espnScheduleSettings)
            );
        }

        private void ProcessLeagueSeasonScoringSettings(ESPNScoringSettings espnScoringSettings, int year)
        {
            CreateLeagueSeasonScoringSettings(espnScoringSettings, year);
            CreateLeagueSeasonScoringItems(espnScoringSettings.ScoringItems, year);
        }

        private void CreateLeagueSeasonScoringSettings(ESPNScoringSettings espnScoringSettings, int year)
        {
            _leagueSeasonScoringSettingsByYear.TryAdd(
                year,
                espnMapper.MapLeagueSeasonScoringSettings(espnScoringSettings)
            );
        }

        private void CreateLeagueSeasonScoringItems(IEnumerable<ESPNScoringItem> espnScoringItems, int year)
        {
            List<LeagueSeasonScoringItem> scoringItems = [];

            foreach (ESPNScoringItem scoringItem in espnScoringItems)
            {
                scoringItems.Add(espnMapper.MapLeagueSeasonScoringItem(scoringItem));
            }

            _leagueSeasonScoringItemsByYear.TryAdd(year, scoringItems);
        }

        private void ProcessLeagueSeasonMembers(
            IEnumerable<ESPNFantasyMember> espnSeasonMembers,
            IEnumerable<ESPNFantasyTeam> espnSeasonTeams,
            int year)
        {
            ILookup<string, ESPNFantasyTeam> espnTeamsByESPNMemberId = espnSeasonTeams
                .SelectMany(espnTeam => espnTeam.Owners.Select(espnMemberId => new
                {
                    ESPNMemberId = espnMemberId,
                    ESPNTeam = espnTeam
                }))
                .ToLookup(x => x.ESPNMemberId, x => x.ESPNTeam);

            List<LeagueSeasonMember> seasonMembers = [];

            foreach (ESPNFantasyMember espnSeasonMember in espnSeasonMembers)
            {
                seasonMembers.Add(espnMapper.MapLeagueSeasonMember(espnSeasonMember));

                ProcessLeagueSeasonMemberTeams(
                    espnSeasonMember,
                    espnTeamsByESPNMemberId[espnSeasonMember.Id],
                    year
                );
            }

            _leagueSeasonMembersByYear.TryAdd(year, seasonMembers);
        }

        private void ProcessLeagueSeasonMemberTeams(
            ESPNFantasyMember espnSeasonMember,
            IEnumerable<ESPNFantasyTeam> espnSeasonMemberTeams,
            int year)
        {
            List<LeagueSeasonMemberTeam> memberTeams = [];

            foreach (ESPNFantasyTeam espnMemberTeam in espnSeasonMemberTeams)
            {
                memberTeams.Add(espnMapper.MapLeagueSeasonMemberTeam(espnSeasonMember.Id, espnMemberTeam.Id));
            }

            _leagueSeasonMemberTeamsLookup.TryAdd((espnSeasonMember.Id, year), memberTeams);
        }

        private void ProcessTeam(ESPNFantasyTeam espnTeam, IEnumerable<ESPNMatchup> espnTeamMatchups, int year)
        {
            // This prevents dual-creating teams that have multiple owners
            if (_teamsLookup.ContainsKey((year, espnTeam.Id))) return;

            CreateTeam(espnTeam, year);
            CreateTeamSeasonStats(espnTeam, year);

            ProcessTeamMatchups(espnTeam, espnTeamMatchups, year);
        }

        private void CreateTeam(ESPNFantasyTeam espnTeam, int year)
        {
            _teamsLookup.TryAdd((year, espnTeam.Id), espnMapper.MapTeam(espnTeam));
        }

        private void CreateTeamSeasonStats(ESPNFantasyTeam espnTeam, int year)
        {
            _teamSeasonStatsLookup.TryAdd((year, espnTeam.Id), espnMapper.MapTeamSeasonStats(espnTeam.Record.Overall));
        }

        private void ProcessTeamMatchups(ESPNFantasyTeam espnTeam, IEnumerable<ESPNMatchup> espnTeamMatchups, int year)
        {
            List<TeamMatchup> teamMatchups = [];

            foreach (ESPNMatchup espnMatchup in espnTeamMatchups)
            {
                int? opponentTeamId = espnTeam.Id == espnMatchup.Home?.TeamId ? espnMatchup.Away?.TeamId : espnMatchup.Home?.TeamId;

                teamMatchups.Add(espnMapper.MapTeamMatchup(year, espnMatchup.MatchupPeriodId, opponentTeamId, espnMatchup.PlayoffTierType));

                ProcessMatchupTeamDetails(espnMatchup, year);
            }

            _teamMatchupLookup.TryAdd((year, espnTeam.Id), teamMatchups);
        }

        private void ProcessMatchupTeamDetails(ESPNMatchup espnMatchup, int year)
        {
            CreateMatchupTeamDetails(espnMatchup.Home, espnMatchup.Winner, true, year, espnMatchup.MatchupPeriodId);
            CreateMatchupTeamDetails(espnMatchup.Away, espnMatchup.Winner, false, year, espnMatchup.MatchupPeriodId);

            ProcessMatchupRosterSpots(espnMatchup.Home, year, espnMatchup.MatchupPeriodId);
            ProcessMatchupRosterSpots(espnMatchup.Away, year, espnMatchup.MatchupPeriodId);
        }

        private void CreateMatchupTeamDetails(ESPNMatchupTeam? espnMatchupTeam, string matchWinner, bool isHomeTeam, int year, int week)
        {
            if (espnMatchupTeam == null) return;
            if (_matchupTeamDetailsLookup.ContainsKey((year, week, espnMatchupTeam.TeamId))) return; //  Prevent double-processing 

            _matchupTeamDetailsLookup.TryAdd(
                (year, week, espnMatchupTeam.TeamId),
                espnMapper.MapMatchupTeamDetails(espnMatchupTeam, matchWinner, isHomeTeam));
        }

        private void ProcessMatchupRosterSpots(ESPNMatchupTeam? espnMatchupTeam, int year, int week)
        {
            if (espnMatchupTeam == null) return;

            // Since we process home and away for each espnMatchup, it's possible the matchup team was already created
            if (_matchupRosterSpotsLookup.ContainsKey((year, week, espnMatchupTeam.TeamId))) return;

            List<MatchupRosterSpot> rosterSpots = [];

            foreach (ESPNRosterSpot espnRosterSpot in espnMatchupTeam.Roster?.Entries ?? [])
            {
                rosterSpots.Add(espnMapper.MapMatchupRosterSpot(espnRosterSpot, year));

                CreateAccumulatedStats(espnRosterSpot.PlayerPoolEntry.Player, espnMatchupTeam.TeamId, year, week);
            }

            _matchupRosterSpotsLookup.TryAdd((year, week, espnMatchupTeam.TeamId), rosterSpots);
        }

        private void CreateAccumulatedStats(ESPNPlayer player, int espnTeamId, int year, int week)
        {
            // This shouldn't be able to happen since a player can onnly be on one team,
            // but just in case we incude this to prevent double processing
            if (_accumulatedStatsLookup.ContainsKey((year, week, espnTeamId, player.Id))) return;

            List<AccumulatedStat> stats = [];

            ESPNPlayerStatProfile? espnLeagueAdjustedStats = player.Stats.FirstOrDefault(espnStatProfile => espnStatProfile.StatSourceId == 0);

            foreach (int statId in espnLeagueAdjustedStats?.AppliedStats?.Keys?.ToList() ?? [])
            {
                stats.Add(espnMapper.MapAccumulatedStat(
                    statId,
                    espnLeagueAdjustedStats!.AppliedStats![statId],
                    espnLeagueAdjustedStats.Stats[statId]
                ));
            }

            _accumulatedStatsLookup.TryAdd((year, week, espnTeamId, player.Id), stats);
        }

        private LeagueImportPlan BuildFlattenedLeagueGraph(League league)
        {
            return new LeagueImportPlan(
                league,
                [.. _newMembers],
                [.. _newPlayers],
                _membersByProviderId,
                _playersByProviderPlayerId,
                _leagueMembersByProviderId,
                _leagueSeasonsByYear,
                _leagueSeasonSettingsByYear,
                _leagueSeasonScheduleSettingsByYear,
                _leagueSeasonScoringSettingsByYear,
                _leagueSeasonScoringItemsByYear,
                _leagueSeasonMembersByYear,
                _leagueSeasonMemberTeamsLookup,
                _teamsLookup,
                _teamSeasonStatsLookup,
                _teamMatchupLookup,
                _matchupTeamDetailsLookup,
                _matchupRosterSpotsLookup,
                _accumulatedStatsLookup
            );
        }
    }
}
