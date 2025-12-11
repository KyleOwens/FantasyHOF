using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mappers
{
    public interface IESPNLeagueMapper
    {
        FantasyLeague MapLeague(List<ESPNSeasonalLeagueData> leagueYears);
    }

    public class ESPNLeagueMapper : IESPNLeagueMapper
    {
        public FantasyLeague MapLeague(List<ESPNSeasonalLeagueData> espnSeasons)
        {
            List<FantasyleagueSeason> seasons = espnSeasons.Select(MapSeason).ToList();
            
            return new FantasyLeague() { Seasons = seasons };
        }

        private FantasyleagueSeason MapSeason(ESPNSeasonalLeagueData espnSeason)
        {
            List<FantasyTeam> teams = espnSeason.Teams.Select(MapTeam).ToList();

            var teamLookup = teams
                .SelectMany(team => team.OwnerIds
                    .Select(ownerId => new { ownerId, team }))
                .ToLookup(x => x.ownerId, x => x.team);

            List<FantasyMember> members = espnSeason.Members.Select(member => MapMember(member, teamLookup)).ToList();
            
            return new FantasyleagueSeason()
            {
                Year = espnSeason.Year,
                Settings = MapSettings(espnSeason.LeagueSettings),
                Members = members,
            };
        }

        private FantasyTeam MapTeam(ESPNFantasyTeam espnTeam)
        {
            return new FantasyTeam()
            {
                Id = espnTeam.Id,
                Name = espnTeam.Name,
                Abbreviation = espnTeam.Abbrev,
                LogoURL = espnTeam.Logo,
                SeasonStats = MapTeamStats(espnTeam.Record.Overall),
                OwnerIds = espnTeam.Owners,
                Matchups = [] // UPDATE LATER
            };
        }

        private FantasyTeamSeasonStats MapTeamStats(ESPNRecordDetails espnTeamStats)
        {
            return new FantasyTeamSeasonStats()
            {
                Wins = espnTeamStats.Wins,
                Losses = espnTeamStats.Losses,
                Ties = espnTeamStats.Ties,
                WinPercentage = espnTeamStats.Percentage,
                PointsFor = espnTeamStats.PointsFor,
                PointsAgainst = espnTeamStats.PointsAgainst
            };
        }

        private FantasyMember MapMember(ESPNFantasyMember member, ILookup<string, FantasyTeam> teamLookup)
        {
            return new FantasyMember()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                DisplayName = member.DisplayName,
                IsLeagueCreator = member.IsLeagueCreator,
                IsLeagueManager = member.IsLeagueManager,
                Teams = teamLookup[member.Id].ToList()
            };
        }

        private FantasyLeagueSettings MapSettings(ESPNLeagueSettings espnSettings)
        {
            return new FantasyLeagueSettings()
            {
                Name = espnSettings.Name,
                ScheduleSettings = MapScheduleSettings(espnSettings.ScheduleSettings),
                ScoringSettings = MapScoringSettings(espnSettings.ScoringSettings)
            };
        }

        private FantasyLeagueScheduleSettings MapScheduleSettings(ESPNScheduleSettings espnScheduleSettings)
        {
            return new FantasyLeagueScheduleSettings()
            {
                MatchupCount = espnScheduleSettings.MatchupPeriodCount,
                MatchupLength = espnScheduleSettings.MatchupPeriodLength,
                PlayoffMatchupLength = espnScheduleSettings.PlayoffMatchypPeriodLength,
                PlayoffTeamCount = espnScheduleSettings.PlayoffTeamCount,
                VariablePlayoffMatchupLength = espnScheduleSettings.VariablePlayoffMatchypPeriodLength
            }; 
        }

        private FantasyLeagueScoringSettings MapScoringSettings(ESPNScoringSettings espnScoringSettings)
        {
            List<FantasyScoringItem> scoringItems = espnScoringSettings.ScoringItems.Select(MapScoringItem).ToList();

            return new FantasyLeagueScoringSettings()
            {
                HomeTeamBonusPoints = espnScoringSettings.HomeTeamBonus,
                MatchupTieRule = espnScoringSettings.MatchupTieRule,
                MatchupTieRuleBy = espnScoringSettings.MatchupTieRuleBy,
                PlayerRankType = espnScoringSettings.PlayerRankType,
                PlayoffHomeTeamBonusPoints = espnScoringSettings.PlayoffHomeTeamBonus,
                PlayoffMatchupTieRule = espnScoringSettings.PlayoffMatchupTieRule,
                PlayoffMatchupTieRuleBy = espnScoringSettings.PlayoffMatchupTieRuleBy,
                ScoringType = espnScoringSettings.ScoringType,
                ScoringItems = scoringItems
            };
        }

        private FantasyScoringItem MapScoringItem(ESPNScoringItem espnScoringItem)
        {
            FantasyStatId statId = (FantasyStatId)espnScoringItem.StatId;

            return new FantasyScoringItem()
            {
                Stat = new FantasyStat() { StatId = statId, Name = statId.ToString() },
                Points = espnScoringItem.Points
            };
        }
    }
}
