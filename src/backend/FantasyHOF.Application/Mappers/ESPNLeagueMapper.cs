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
        League MapLeague(string leagueId);
        LeagueSeason MapLeagueSeason(ESPNSeasonalLeagueData seasonData);
        LeagueSeasonSettings MapLeagueSeasonSettings(ESPNLeagueSettings espnSettings);
        LeagueSeasonScheduleSettings MapLeagueSeasonScheduleSettings(ESPNScheduleSettings espnSettings);
        LeagueSeasonScoringSettings MapLeagueSeasonScoringSettings(ESPNScoringSettings espnSettings);
        LeagueSeasonScoringItem MapLeagueSeasonScoringItem(ESPNScoringItem espnItem);
    }

    public class ESPNLeagueMapper : IESPNLeagueMapper
    {
        public League MapLeague(string leagueId)
        {
            return new League() {
                FantasyProviderId = FantasyProviderId.ESPN, 
                ProviderLeagueId = leagueId, 
                SportId = SportId.Football  
            };
        }

        public LeagueSeason MapLeagueSeason(ESPNSeasonalLeagueData seasonData)
        {
            return new LeagueSeason()
            {
                Year = seasonData.Year,
            };
        }

        public LeagueSeasonSettings MapLeagueSeasonSettings(ESPNLeagueSettings espnSettings)
        {
            return new LeagueSeasonSettings()
            {
                LeagueName = espnSettings.Name,
            };
        }

        public LeagueSeasonScheduleSettings MapLeagueSeasonScheduleSettings(ESPNScheduleSettings espnScheduleSettings)
        {
            return new LeagueSeasonScheduleSettings()
            {
                MatchupCount = espnScheduleSettings.MatchupPeriodCount,
                MatchupLength = espnScheduleSettings.MatchupPeriodLength,
                PlayoffMatchupLength = espnScheduleSettings.PlayoffMatchypPeriodLength,
                PlayoffTeamCount = espnScheduleSettings.PlayoffTeamCount,
                VariablePlayoffMatchupLength = espnScheduleSettings.VariablePlayoffMatchypPeriodLength
            };
        }

        public LeagueSeasonScoringSettings MapLeagueSeasonScoringSettings(ESPNScoringSettings espnScoringSettings)
        {
            return new LeagueSeasonScoringSettings()
            {
                HomeTeamBonusPoints = espnScoringSettings.HomeTeamBonus,
                MatchupTieRule = espnScoringSettings.MatchupTieRule,
                MatchupTieRuleBy = espnScoringSettings.MatchupTieRuleBy,
                PlayerRankType = espnScoringSettings.PlayerRankType,
                PlayoffHomeTeamBonusPoints = espnScoringSettings.PlayoffHomeTeamBonus,
                PlayoffMatchupTieRule = espnScoringSettings.PlayoffMatchupTieRule,
                PlayoffMatchupTieRuleBy = espnScoringSettings.PlayoffMatchupTieRuleBy,
                ScoringType = espnScoringSettings.ScoringType,
            };
        }

        public LeagueSeasonScoringItem MapLeagueSeasonScoringItem(ESPNScoringItem espnScoringItem)
        {
            StatId statId = (StatId)espnScoringItem.StatId;

            return new LeagueSeasonScoringItem()
            {
                StatId = statId,
                Points = espnScoringItem.Points,
            };
        }

        //private Team MapTeam(ESPNFantasyTeam espnTeam)
        //{
        //    return new Team()
        //    {
        //        Id = espnTeam.Id,
        //        Name = espnTeam.Name,
        //        Abbreviation = espnTeam.Abbrev,
        //        LogoURL = espnTeam.Logo,
        //        SeasonStats = MapTeamStats(espnTeam.Record.Overall),
        //        OwnerIds = espnTeam.Owners,
        //        Matchups = [] // UPDATE LATER
        //    };
        //}

        private TeamSeasonStats MapTeamStats(ESPNRecordDetails espnTeamStats)
        {
            return new TeamSeasonStats()
            {
                Wins = espnTeamStats.Wins,
                Losses = espnTeamStats.Losses,
                Ties = espnTeamStats.Ties,
                WinPercentage = espnTeamStats.Percentage,
                PointsFor = espnTeamStats.PointsFor,
                PointsAgainst = espnTeamStats.PointsAgainst
            };
        }

        //private FantasyMember MapMember(ESPNFantasyMember member, ILookup<string, Team> teamLookup)
        //{
        //    return new FantasyMember()
        //    {
        //        Id = member.Id,
        //        FirstName = member.FirstName,
        //        LastName = member.LastName,
        //        DisplayName = member.DisplayName,
        //        IsLeagueCreator = member.IsLeagueCreator,
        //        IsLeagueManager = member.IsLeagueManager,
        //        Teams = teamLookup[member.Id].ToList()
        //    };
        //}






    }
}
