using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN.Constants;
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
        LeagueSeasonMember MapLeagueSeasonMember(ESPNFantasyMember espnMember);
        FantasyMember MapFantasyMember(ESPNFantasyMember espnMember);
        LeagueSeasonMemberTeam MapLeagueSeasonMemberTeam();
        Team MapTeam(ESPNFantasyTeam espnTeam);
        TeamSeasonStats MapTeamSeasonStats(ESPNRecordDetails espnTeamStats);
        TeamMatchup MapTeamMatchup(int week, string espnMatchupType, bool isHomeTeam, string matchWinner, ESPNMatchupTeam espnTeam);
        MatchupRosterSpot MapMatchupRosterSpot(ESPNRosterSpot espnRosterSpot, int year);
        Player MapPlayer(ESPNPlayer espnPlayer);
        AccumulatedStat MapAccumulatedStat(int statId, decimal statValue, decimal statScore);
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

        public LeagueSeasonMember MapLeagueSeasonMember(ESPNFantasyMember espnMember)
        {
            return new LeagueSeasonMember()
            {
                IsLeagueCreator = espnMember.IsLeagueCreator,
                IsLeagueManager = espnMember.IsLeagueManager
            };
        }

        public FantasyMember MapFantasyMember(ESPNFantasyMember espnMember)
        {
            return new FantasyMember()
            {
                FantasyProviderId = FantasyProviderId.ESPN,
                ProviderMemberId = espnMember.Id,
                DisplayName = espnMember.DisplayName,
                FirstName = espnMember.FirstName,
                LastName = espnMember.LastName
            };
        }

        public LeagueSeasonMemberTeam MapLeagueSeasonMemberTeam()
        {
            return new LeagueSeasonMemberTeam();
        }

        public Team MapTeam(ESPNFantasyTeam espnTeam)
        {
            return new Team()
            {
                ProviderTeamId = espnTeam.Id,
                Abbreviation = espnTeam.Abbrev,
                LogoURL = espnTeam.Logo,
                Name = espnTeam.Name,
            };
        }

        public TeamSeasonStats MapTeamSeasonStats(ESPNRecordDetails espnTeamStats)
        {
            return new TeamSeasonStats()
            {
                Wins = espnTeamStats.Wins,
                Losses = espnTeamStats.Losses,
                Ties = espnTeamStats.Ties,
                WinPercentage = Math.Round(espnTeamStats.Percentage, 2, MidpointRounding.AwayFromZero),
                PointsAgainst = Math.Round(espnTeamStats.PointsAgainst, 2, MidpointRounding.AwayFromZero),
                PointsFor = Math.Round(espnTeamStats.PointsFor, 2, MidpointRounding.AwayFromZero)
            };
        }

        public TeamMatchup MapTeamMatchup(
            int week, 
            string espnMatchupType, 
            bool isHomeTeam, 
            string matchWinner,
            ESPNMatchupTeam espnTeam)
        {
            MatchupTypeId matchupType = espnMatchupType switch
            {
                ESPNPlayoffTierTypes.None => MatchupTypeId.RegularSeason,
                ESPNPlayoffTierTypes.WinnersBracket => MatchupTypeId.WinnersBracket,
                ESPNPlayoffTierTypes.WinnersConsolationBracket => MatchupTypeId.WinnersConsolation,
                ESPNPlayoffTierTypes.LosersConsolationBracket => MatchupTypeId.LosersBracket,
                _ => MatchupTypeId.Unknown
            };

            MatchupOutcomeId matchOutcomeId = matchWinner switch
            {
                ESPNWinnerValues.Away => isHomeTeam ? MatchupOutcomeId.Loss : MatchupOutcomeId.Win,
                ESPNWinnerValues.Home => isHomeTeam ? MatchupOutcomeId.Win : MatchupOutcomeId.Loss,
                ESPNWinnerValues.Tie => MatchupOutcomeId.Tie,
                ESPNWinnerValues.Undecided => MatchupOutcomeId.Undecided,
                _ => MatchupOutcomeId.Unknown
            };

            return new TeamMatchup()
            {
                Week = week,
                Score = Math.Round(espnTeam.TotalPoints, 2, MidpointRounding.AwayFromZero),
                MatchupTypeId = matchupType,
                MatchupOutcomeId = matchOutcomeId
            };
        }

        public MatchupRosterSpot MapMatchupRosterSpot(ESPNRosterSpot espnRosterSpot, int leagueYear)
        {
            return new MatchupRosterSpot()
            {
                PositionId = leagueYear >= 2018 ? (PositionId)espnRosterSpot.lineupSlotId : PositionId.Unknown,
                PointsScored = Math.Round(espnRosterSpot.PlayerPoolEntry.AppliedStatTotal, 2, MidpointRounding.AwayFromZero)
            };
        }

        public Player MapPlayer(ESPNPlayer espnPlayer)
        {
            return new Player()
            {
                ProviderId = FantasyProviderId.ESPN,
                ProviderPlayerId = espnPlayer.Id,
                FirstName = espnPlayer.FirstName,
                LastName = espnPlayer.LastName,
                FullName = espnPlayer.FullName,
            };
        }

        public AccumulatedStat MapAccumulatedStat(int statId, decimal statValue, decimal statScore)
        {
            return new AccumulatedStat()
            {
                StatId = (StatId)statId,
                StatValue = Math.Round(statValue, 2, MidpointRounding.AwayFromZero),
                PointsScored = Math.Round(statScore, 2, MidpointRounding.AwayFromZero)
            };
        }
    }
}
