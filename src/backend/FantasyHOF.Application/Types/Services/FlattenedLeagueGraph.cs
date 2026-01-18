using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Services
{
    public record FlattenedLeagueGraph(
        League League,
        IReadOnlyList<FantasyMember> Members,
        IReadOnlyList<LeagueMember> LeagueMembers,
        IReadOnlyList<LeagueSeason> LeagueSeasons,
        IReadOnlyList<LeagueSeasonSettings> LeagueSeasonSettings,
        IReadOnlyList<LeagueSeasonScheduleSettings> LeagueSeassonScheduleSettings,
        IReadOnlyList<LeagueSeasonScoringSettings> LeagueSeasonScoringSettings,
        IReadOnlyList<LeagueSeasonScoringSettings> LeagueSeasonScoringItems,
        IReadOnlyList<LeagueSeasonMember> LeagueSeasonMembers,
        IReadOnlyList<LeagueSeasonMemberTeam> LeagueSeasonMemberTeams,
        IReadOnlyList<Team> Team,
        IReadOnlyList<TeamSeasonStats> TeamSeasonStats,
        IReadOnlyList<TeamMatchup> TeamMatchups,
        IReadOnlyList<MatchupTeamDetails> MatchupTeamDetails,
        IReadOnlyList<MatchupRosterSpot> MatchupRosterSpots,
        IReadOnlyList<Player> Players,
        IReadOnlyList<AccumulatedStat> AccumulatedStats
    );
}
