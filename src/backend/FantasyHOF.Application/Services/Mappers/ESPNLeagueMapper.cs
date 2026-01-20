using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.ESPN.Constants;
using FantasyHOF.ESPN.Types.Models;
using FantasyHOF.ESPN.Types.Outputs;

namespace FantasyHOF.Application.Services.Mappers
{
    public class ESPNLeagueMapper(string userId)
    {
        public League MapLeague(string leagueId, List<LeagueSeason> leagueSeasons, List<LeagueSeasonSettings> settings)
        {
            LeagueSeason? mostRecentSeason = leagueSeasons.Last();
            LeagueSeasonSettings? mostRecentSettings = settings.Last();

            return new League()
            {
                UserId = userId,
                FantasyProviderId = FantasyProviderId.ESPN,
                ProviderLeagueId = leagueId,
                SportId = SportId.Football,
                CurrentLeagueName = mostRecentSettings.LeagueName ?? "",
                CurrentLeagueYear = mostRecentSeason?.Year ?? 0
            };
        }

        public LeagueMember MapLeagueMember(string ESPNMemberId, IEnumerable<ESPNSeasonalLeagueData> memberSeasons)
        {
            IEnumerable<ESPNFantasyTeam> memberTeams = memberSeasons
                .Last()
                .Teams.Where(x => x.Owners.Any(ownerId => ownerId == ESPNMemberId));

            ESPNFantasyTeam? currentTeam = memberTeams.Any() ? memberTeams.Last() : null;

            return new LeagueMember()
            {
                UserId = userId,
                Firstyear = memberSeasons.First().Year,
                LastYear = memberSeasons.Last().Year,
                Tenure = memberSeasons.Count(),
                CurrentTeamName = currentTeam?.Name ?? "",
                CurrentTeamLogoURL = currentTeam?.Logo ?? "",
            };
        }

        public LeagueSeason MapLeagueSeason(ESPNSeasonalLeagueData seasonData)
        {
            return new LeagueSeason()
            {
                UserId = userId,
                Year = seasonData.Year,
            };
        }

        public LeagueSeasonSettings MapLeagueSeasonSettings(ESPNLeagueSettings espnSettings)
        {
            return new LeagueSeasonSettings()
            {
                UserId = userId,
                LeagueName = espnSettings.Name,
            };
        }

        public LeagueSeasonScheduleSettings MapLeagueSeasonScheduleSettings(ESPNScheduleSettings espnScheduleSettings)
        {
            return new LeagueSeasonScheduleSettings()
            {
                UserId = userId,
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
                UserId = userId,
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
                UserId = userId,
                StatId = statId,
                Points = espnScoringItem.Points,
            };
        }

        public LeagueSeasonMember MapLeagueSeasonMember(ESPNFantasyMember espnMember)
        {
            return new LeagueSeasonMember()
            {
                UserId = userId,
                ProviderMemberId = espnMember.Id,
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

        public LeagueSeasonMemberTeam MapLeagueSeasonMemberTeam(string espnMemberId, int espnTeamId)
        {
            return new LeagueSeasonMemberTeam
            {
                UserId = userId,
                ProviderMemberId = espnMemberId,
                ProviderTeamId = espnTeamId
            };
        }

        public Team MapTeam(ESPNFantasyTeam espnTeam)
        {
            return new Team()
            {
                UserId = userId,
                ProviderTeamId = espnTeam.Id,
                SeasonRank = espnTeam.RankCalculatedFinal,
                Abbreviation = espnTeam.Abbrev,
                LogoURL = espnTeam.Logo,
                Name = espnTeam.Name,
            };
        }

        public TeamSeasonStats MapTeamSeasonStats(ESPNRecordDetails espnTeamStats)
        {
            return new TeamSeasonStats()
            {
                UserId = userId,
                Wins = espnTeamStats.Wins,
                Losses = espnTeamStats.Losses,
                Ties = espnTeamStats.Ties,
                WinPercentage = Math.Round(espnTeamStats.Percentage, 2, MidpointRounding.AwayFromZero),
                PointsAgainst = Math.Round(espnTeamStats.PointsAgainst, 2, MidpointRounding.AwayFromZero),
                PointsFor = Math.Round(espnTeamStats.PointsFor, 2, MidpointRounding.AwayFromZero)
            };
        }

        public TeamMatchup MapTeamMatchup(
            int year,
            int week,
            int? espnOpponentTeamId,
            string espnMatchupType)
        {
            MatchupTypeId matchupType = espnMatchupType switch
            {
                ESPNPlayoffTierTypes.None => MatchupTypeId.RegularSeason,
                ESPNPlayoffTierTypes.WinnersBracket => MatchupTypeId.WinnersBracket,
                ESPNPlayoffTierTypes.WinnersConsolationBracket => MatchupTypeId.WinnersConsolation,
                ESPNPlayoffTierTypes.LosersConsolationBracket => MatchupTypeId.LosersBracket,
                _ => MatchupTypeId.Unknown
            };

            return new TeamMatchup()
            {
                UserId = userId,
                Year = year,
                Week = week,
                OpponentProviderTeamId = espnOpponentTeamId,
                MatchupTypeId = matchupType,
            };
        }

        public MatchupTeamDetails MapMatchupTeamDetails(ESPNMatchupTeam espnTeam, string matchWinner, bool isHomeTeam)
        {
            MatchupOutcomeId matchOutcomeId = matchWinner switch
            {
                ESPNWinnerValues.Away => isHomeTeam ? MatchupOutcomeId.Loss : MatchupOutcomeId.Win,
                ESPNWinnerValues.Home => isHomeTeam ? MatchupOutcomeId.Win : MatchupOutcomeId.Loss,
                ESPNWinnerValues.Tie => MatchupOutcomeId.Tie,
                ESPNWinnerValues.Undecided => MatchupOutcomeId.Undecided,
                _ => MatchupOutcomeId.Unknown
            };

            return new MatchupTeamDetails()
            {
                UserId = userId,
                Score = Math.Round(espnTeam.TotalPoints, 2, MidpointRounding.AwayFromZero),
                MatchupOutcomeId = matchOutcomeId
            };
        }

        public MatchupRosterSpot MapMatchupRosterSpot(ESPNRosterSpot espnRosterSpot, int leagueYear)
        {
            return new MatchupRosterSpot()
            {
                UserId = userId,
                ProviderPlayerId = espnRosterSpot.PlayerPoolEntry.Player.Id,
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
                UserId = userId,
                StatId = (StatId)statId,
                StatValue = Math.Round(statValue, 2, MidpointRounding.AwayFromZero),
                PointsScored = Math.Round(statScore, 2, MidpointRounding.AwayFromZero)
            };
        }
    }
}
