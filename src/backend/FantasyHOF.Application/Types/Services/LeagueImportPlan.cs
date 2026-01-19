using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Services
{
    public record LeagueImportPlan(
        League League,
        List<FantasyMember> NewMembers,
        List<Player> NewPlayers,
        Dictionary<string, FantasyMember> MemberByProviderId,
        Dictionary<int, Player> PlayersByProviderId,
        Dictionary<string, LeagueMember> LeagueMembersByProviderId,
        Dictionary<int, LeagueSeason> LeagueSeasonsByYear,
        Dictionary<int, LeagueSeasonSettings> LeagueSeasonSettingsByYear,
        Dictionary<int, LeagueSeasonScheduleSettings> LeagueSeasonScheduleSettingsByYear,
        Dictionary<int, LeagueSeasonScoringSettings> LeagueSeasonScoringSettingsByYear,
        Dictionary<int, List<LeagueSeasonScoringItem>> LeagueSeasonScoringItemsByYear,
        Dictionary<int, List<LeagueSeasonMember>> LeagueSeasonMembersByYear,
        Dictionary<(string espnMemberId, int year), List<LeagueSeasonMemberTeam>> LeagueSeasonMembersTeamsLookup,
        Dictionary<(int year, int espnTeamId), Team> TeamsLookup,
        Dictionary<(int year, int espnTeamId), TeamSeasonStats> TeamSeasonStatsLookup,
        Dictionary<(int year, int espnTeamId), List<TeamMatchup>> TeamMatchupLookup,
        Dictionary<(int year, int week, int espnTeamId), MatchupTeamDetails> MatchupTeamDetailsLookup,
        Dictionary<(int year, int week, int espnTeamId), List<MatchupRosterSpot>> MatchupRosterSpotsLookup,
        Dictionary<(int year, int week, int espnTeamId, int playerId), List<AccumulatedStat>> AccumulatedStatsLookup
    )
    {
        public List<LeagueMember> LeagueMembers => [.. LeagueMembersByProviderId.Values];
        public List<LeagueSeason> LeagueSeasons => [.. LeagueSeasonsByYear.Values];
        public List<LeagueSeasonSettings> LeagueSeasonSettings => [.. LeagueSeasonSettingsByYear.Values];
        public List<LeagueSeasonScheduleSettings> LeagueSeasonScheduleSettings => [.. LeagueSeasonScheduleSettingsByYear.Values];
        public List<LeagueSeasonScoringSettings> LeagueSeasonScoringSettings => [.. LeagueSeasonScoringSettingsByYear.Values];
        public List<LeagueSeasonScoringItem> LeagueSeasonScoringItems => [.. LeagueSeasonScoringItemsByYear.Values.SelectMany(x => x)];
        public List<LeagueSeasonMember> LeagueSeasonMembers => [.. LeagueSeasonMembersByYear.Values.SelectMany(x => x)];
        public List<LeagueSeasonMemberTeam> LeagueSeasonMemberTeams => [.. LeagueSeasonMembersTeamsLookup.Values.SelectMany(x => x)];
        public List<Team> Teams => [.. TeamsLookup.Values];
        public List<TeamSeasonStats> TeamSeasonStats => [.. TeamSeasonStatsLookup.Values];
        public List<TeamMatchup> TeamMatchups => [.. TeamMatchupLookup.Values.SelectMany(x => x)];
        public List<MatchupTeamDetails> MatchupTeamDetails => [.. MatchupTeamDetailsLookup.Values];
        public List<MatchupRosterSpot> MatchupRosterSpots => [.. MatchupRosterSpotsLookup.Values.SelectMany(x => x)];
        public List<AccumulatedStat> AccumulatedStats => [.. AccumulatedStatsLookup.Values.SelectMany(x => x)];
    }
}
