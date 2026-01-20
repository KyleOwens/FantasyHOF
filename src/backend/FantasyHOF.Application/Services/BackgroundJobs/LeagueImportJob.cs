using EFCore.BulkExtensions;
using FantasyHOF.Application.Queries.ESPNQueries;
using FantasyHOF.Application.Services.Events;
using FantasyHOF.Application.Types.Services;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN.Types.Inputs;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace FantasyHOF.Application.Services.BackgroundJobs
{
    public interface ILeagueImportJob
    {
        Task ExecuteAsync(int pendingLeagueId, string userid, ESPNLeagueCredentials credentials, IJobCancellationToken ct);
    }

    public class LeagueImportJob(
        FantasyHOFDBContext database,
        IMediator mediator,
        ILeagueImportEventSender eventSender,
        ILogger<LeagueImportJob> logger
    ) : ILeagueImportJob
    {
        [JobDisplayName("Import ESPN League {1}")]
        public async Task ExecuteAsync(int pendingLeagueId, string userId, ESPNLeagueCredentials credentials, IJobCancellationToken jobToken)
        {
            CancellationToken ct = jobToken.ShutdownToken;

            database.SetRLSUserId(userId);

            LeagueImport? import = await database.LeagueImports
                .Include(x => x.User)
                    .ThenInclude(x => x.Leagues)
                .SingleAsync(x => x.Id == pendingLeagueId, ct);

            try
            {
                await eventSender.StartImport(import, ct);

                LeagueImportPlan importPlan = await mediator.Send(new GetESPNLeagueImportPlanQuery(userId, credentials, import), ct);

                await eventSender.StartSaving(import, ct);

                IDbContextTransaction transaction = await database.Database.BeginTransactionAsync();
                import.User.RemoveLeagueIfExists(FantasyProviderId.ESPN, credentials.LeagueId);
                await InsertRecords(importPlan, import, ct);
                await transaction.CommitAsync();

                await eventSender.Complete(import, importPlan.League.Id, ct);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occurred while processing the league import");
                await eventSender.Error(import, ct);
            }
        }

        private async Task InsertRecords(LeagueImportPlan flatLeague, LeagueImport import, CancellationToken ct)
        {
            var config = new BulkConfig
            {
                SetOutputIdentity = true,
                PreserveInsertOrder = true,
            };

            await eventSender.StartSavingMiscellaneousData(import, ct);

            await InsertNonDependentEntities(flatLeague, config, ct);

            await eventSender.StartSavingMembers(import, ct);

            await InsertLeagueMembers(flatLeague, config, ct);

            await eventSender.StartSavingSeasons(import, ct);

            await InsertLeagueSeasons(flatLeague, config, ct);
            await InsertLeagueSeasonSettings(flatLeague, config, ct);
            await InsertLeagueSeasonScheduleSettings(flatLeague, config, ct);
            await InsertLeagueSeasonScoringSettings(flatLeague, config, ct);
            await InsertLeagueSeasonScoringItems(flatLeague, config, ct);
            await InsertLeagueSeasonMembers(flatLeague, config, ct);

            await eventSender.StartSavingTeams(import, ct);

            await InsertTeams(flatLeague, config, ct);
            await InsertLeagueSeasonMemberTeams(flatLeague, config, ct);
            await InsertTeamSeasonStats(flatLeague, config, ct);

            await eventSender.StartSavingMatchups(import, ct);

            await InsertMatchupTeamDetails(flatLeague, config, ct);
            await InsertTeamMatchups(flatLeague, config, ct);

            await eventSender.StartSavingRosters(import, ct);

            await InsertMatchupRosterSpots(flatLeague, config, ct);

            await eventSender.StartSavingStats(import, ct);

            await InsertAccumulatedStats(flatLeague, config, ct);
        }

        private async Task InsertNonDependentEntities(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            await database.BulkInsertAsync([flatLeague.League], config, cancellationToken: ct);

            if (flatLeague.NewMembers.Count != 0)
            {
                await database.BulkInsertAsync(flatLeague.NewMembers, config, cancellationToken: ct);
            }

            if (flatLeague.NewPlayers.Count != 0)
            {
                await database.BulkInsertAsync(flatLeague.NewPlayers, config, cancellationToken: ct);
            }
        }

        private async Task InsertLeagueSeasons(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (LeagueSeason season in flatLeague.LeagueSeasons)
            {
                season.LeagueId = flatLeague.League.Id;
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasons, config, cancellationToken: ct);
        }

        private async Task InsertLeagueMembers(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var (espnMemberId, leagueMember) in flatLeague.LeagueMembersByProviderId)
            {
                leagueMember.LeagueId = flatLeague.League.Id;
                leagueMember.MemberId = flatLeague.MemberByProviderId[espnMemberId].Id;
            }

            await database.BulkInsertAsync(flatLeague.LeagueMembers, config, cancellationToken: ct);
        }

        private async Task InsertLeagueSeasonSettings(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var (year, settings) in flatLeague.LeagueSeasonSettingsByYear)
            {
                settings.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasonSettings, config, cancellationToken: ct);
        }

        private async Task InsertLeagueSeasonScheduleSettings(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var (year, scheduleSettings) in flatLeague.LeagueSeasonScheduleSettingsByYear)
            {
                scheduleSettings.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasonScheduleSettings, config, cancellationToken: ct);
        }

        private async Task InsertLeagueSeasonScoringSettings(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var (year, scoringSettings) in flatLeague.LeagueSeasonScoringSettingsByYear)
            {
                scoringSettings.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasonScoringSettings, config, cancellationToken: ct);
        }

        private async Task InsertLeagueSeasonScoringItems(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var (year, scoringItems) in flatLeague.LeagueSeasonScoringItemsByYear)
            {
                foreach (LeagueSeasonScoringItem scoringItem in scoringItems)
                {
                    scoringItem.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
                }
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasonScoringItems, config, cancellationToken: ct);
        }

        private async Task InsertLeagueSeasonMembers(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var (year, seasonMembers) in flatLeague.LeagueSeasonMembersByYear)
            {
                foreach (LeagueSeasonMember seasonMember in seasonMembers)
                {
                    seasonMember.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
                    seasonMember.MemberId = flatLeague.MemberByProviderId[seasonMember.ProviderMemberId].Id;
                }
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasonMembers, config, cancellationToken: ct);
        }

        private async Task InsertTeams(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((year, _), team) in flatLeague.TeamsLookup)
            {
                team.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
            }

            await database.BulkInsertAsync(flatLeague.Teams, config, cancellationToken: ct);
        }

        private async Task InsertLeagueSeasonMemberTeams(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((espnMemberId, year), memberTeams) in flatLeague.LeagueSeasonMembersTeamsLookup)
            {
                foreach (LeagueSeasonMemberTeam memberTeam in memberTeams)
                {
                    memberTeam.LeagueSeasonId = flatLeague.LeagueSeasonsByYear[year].Id;
                    memberTeam.MemberId = flatLeague.MemberByProviderId[espnMemberId].Id;
                    memberTeam.TeamId = flatLeague.TeamsLookup[(year, memberTeam.ProviderTeamId)].Id;
                }
            }

            await database.BulkInsertAsync(flatLeague.LeagueSeasonMemberTeams, config, cancellationToken: ct);
        }

        private async Task InsertTeamSeasonStats(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((year, espnTeamId), teamStats) in flatLeague.TeamSeasonStatsLookup)
            {
                teamStats.TeamId = flatLeague.TeamsLookup[(year, espnTeamId)].Id;
            }

            await database.BulkInsertAsync(flatLeague.TeamSeasonStats, config, cancellationToken: ct);
        }

        private async Task InsertMatchupTeamDetails(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((year, _, providerTeamId), matchupDetails) in flatLeague.MatchupTeamDetailsLookup)
            {
                matchupDetails.TeamId = flatLeague.TeamsLookup[(year, providerTeamId)].Id;
            }

            await database.BulkInsertAsync(flatLeague.MatchupTeamDetails, config, cancellationToken: ct);
        }

        private async Task InsertTeamMatchups(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((year, espnTeamId), teamMatchups) in flatLeague.TeamMatchupLookup)
            {
                foreach (TeamMatchup teamMatchup in teamMatchups)
                {
                    teamMatchup.TeamId = flatLeague.TeamsLookup[(year, espnTeamId)].Id;
                    teamMatchup.OwnerMatchupDetailsId = flatLeague.MatchupTeamDetailsLookup[(year, teamMatchup.Week, espnTeamId)].Id;

                    if (teamMatchup.OpponentProviderTeamId != null)
                    {
                        teamMatchup.OpponentMatchupDetailsId = flatLeague.MatchupTeamDetailsLookup[(year, teamMatchup.Week, teamMatchup.OpponentProviderTeamId.Value)].Id;
                    }
                }
            }

            await database.BulkInsertAsync(flatLeague.TeamMatchups, config, cancellationToken: ct);
        }

        private async Task InsertMatchupRosterSpots(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((year, week, espnTeamId), rosterSpots) in flatLeague.MatchupRosterSpotsLookup)
            {
                foreach (MatchupRosterSpot rosterSpot in rosterSpots)
                {
                    rosterSpot.MatchupTeamDetailsId = flatLeague.MatchupTeamDetailsLookup[(year, week, espnTeamId)].Id;
                    rosterSpot.PlayerId = flatLeague.PlayersByProviderId[rosterSpot.ProviderPlayerId].Id;
                }
            }

            await database.BulkInsertAsync(flatLeague.MatchupRosterSpots, config, cancellationToken: ct);
        }

        private async Task InsertAccumulatedStats(LeagueImportPlan flatLeague, BulkConfig config, CancellationToken ct)
        {
            foreach (var ((year, week, espnTeamId, playerId), accumulatedStats) in flatLeague.AccumulatedStatsLookup)
            {
                foreach (AccumulatedStat stat in accumulatedStats)
                {
                    stat.MatchupRosterSpotId = flatLeague.MatchupRosterSpotsLookup[(year, week, espnTeamId)].First(x => x.ProviderPlayerId == playerId).Id;
                }
            }

            await database.BulkInsertAsync(flatLeague.AccumulatedStats, config, cancellationToken: ct);
        }
    }
}
