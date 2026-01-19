using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using HotChocolate.Subscriptions;

namespace FantasyHOF.Application.Services.Events
{
    public interface ILeagueImportEventSender
    {
        public Task StartImport(LeagueImport import, CancellationToken ct);
        public Task StartLoadingSeasonalData(LeagueImport import, CancellationToken ct);
        public Task StartLoadingWeeklyData(LeagueImport impot, CancellationToken ct);
        public Task StartFormattingData(LeagueImport import, CancellationToken ct);
        public Task StartSaving(LeagueImport import, CancellationToken ct);
        public Task StartSavingMiscellaneousData(LeagueImport import, CancellationToken ct);
        public Task StartSavingMembers(LeagueImport import, CancellationToken ct);
        public Task StartSavingSeasons(LeagueImport import, CancellationToken ct);
        public Task StartSavingTeams(LeagueImport import, CancellationToken ct);
        public Task StartSavingMatchups(LeagueImport import, CancellationToken ct);
        public Task StartSavingRosters(LeagueImport import, CancellationToken ct);
        public Task StartSavingStats(LeagueImport import, CancellationToken ct);
        public Task Complete(LeagueImport import, int leagueId, CancellationToken ct);
        public Task Error(LeagueImport import, CancellationToken ct);
    }

    public class LeagueImportEventSender(FantasyHOFDBContext database, ITopicEventSender eventSender) : ILeagueImportEventSender
    {
        private async Task SendEvent(LeagueImport import, CancellationToken ct)
        {
            await database.SaveChangesAsync(ct);
            await eventSender.SendAsync($"{nameof(LeagueImport)}_{import.UserId}", import, ct);
        }

        public async Task StartImport(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.Queued;
            import.Progress = 0;

            await SendEvent(import, ct);
        }

        public async Task StartLoadingSeasonalData(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.LoadingSeasonalData;
            import.Progress = 5;

            await SendEvent(import, ct);
        }

        public async Task StartLoadingWeeklyData(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.LoadingWeeklylData;
            import.Progress = 10;

            await SendEvent(import, ct);
        }

        public async Task StartFormattingData(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.FormattingData;
            import.Progress = 15;
        }

        public async Task StartSaving(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingData;
            import.Progress = 20;

            await SendEvent(import, ct);
        }

        public async Task StartSavingMiscellaneousData(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingMiscellaneousData;
            import.Progress = 25;

            await SendEvent(import, ct);
        }

        public async Task StartSavingMembers(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingMembers;
            import.Progress = 30;

            await SendEvent(import, ct);
        }

        public async Task StartSavingSeasons(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingSeasons;
            import.Progress = 35;

            await SendEvent(import, ct);
        }

        public async Task StartSavingTeams(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingTeams;
            import.Progress = 50;

            await SendEvent(import, ct);
        }

        public async Task StartSavingMatchups(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingMatchups;
            import.Progress = 60;

            await SendEvent(import, ct);
        }

        public async Task StartSavingRosters(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingRosters;
            import.Progress = 70;

            await SendEvent(import, ct);
        }

        public async Task StartSavingStats(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingStats;
            import.Progress = 90;

            await SendEvent(import, ct);
        }

        public async Task Complete(LeagueImport import, int leagueId, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.Completed;
            import.Progress = 100;
            import.LeagueId = leagueId;

            await SendEvent(import, ct);
        }

        public async Task Error(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.Failed;
            import.Progress = 100;
            import.Error = "An unexpected error occurred while importing your league's data. Please try again later.";

            await SendEvent(import, ct);
        }
    }
}
