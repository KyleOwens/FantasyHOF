using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using HotChocolate.Subscriptions;

namespace FantasyHOF.Application.Services.Events
{
    public interface ILeagueImportEventSender
    {
        public Task StartImport(LeagueImport import, CancellationToken ct);
        public Task StartLoadingData(LeagueImport import, CancellationToken ct);
        public Task StartFormattingData(LeagueImport import, CancellationToken ct);
        public Task StartSaving(LeagueImport import, CancellationToken ct);
        public Task Complete(LeagueImport import, int leagueId, CancellationToken ct);
        public Task Error(LeagueImport import, CancellationToken ct);
    }

    public class LeagueImportEventSender(FantasyHOFDBContext database, ITopicEventSender eventSender) : ILeagueImportEventSender
    {
        private async Task SendEvent(LeagueImport import, CancellationToken ct)
        {
            await database.SaveChangesAsync();
            await eventSender.SendAsync($"{nameof(LeagueImport)}_{import.UserId}", import, ct);
        }

        public async Task StartImport(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.Queued;
            import.Progress = 0;

            await SendEvent(import, ct);
        }

        public async Task StartLoadingData(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.LoadingData;
            import.Progress = 5;

            await SendEvent(import, ct);
        }

        public async Task StartFormattingData(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.FormattingData;
            import.Progress = 30;
        }

        public async Task StartSaving(LeagueImport import, CancellationToken ct)
        {
            import.StatusId = LeagueImportStatusId.SavingData;
            import.Progress = 40;

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
