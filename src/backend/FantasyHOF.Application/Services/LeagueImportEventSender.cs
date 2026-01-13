using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using HotChocolate.Subscriptions;

namespace FantasyHOF.Application.Services
{
    public interface ILeagueImportEventSender
    {
        public Task StartImport(LeagueImport import, CancellationToken cancellationToken);
        public Task StartSaving(LeagueImport import, CancellationToken cancellationToken);
        public Task Complete(LeagueImport import, int leagueId, CancellationToken cancellationToken);
        public Task Error(LeagueImport import, CancellationToken cancellationToken);
    }

    public class LeagueImportEventSender(FantasyHOFDBContext database, ITopicEventSender eventSender) : ILeagueImportEventSender
    {
        private async Task SendEvent(LeagueImport import, CancellationToken cancellationToken)
        {
            await database.SaveChangesAsync();
            await eventSender.SendAsync($"{nameof(LeagueImport)}_{import.UserId}", import, cancellationToken);
        }

        public async Task StartImport(LeagueImport import, CancellationToken cancellationToken)
        {
            import.StatusId = LeagueImportStatusId.LoadingData;
            import.Progress = 0;

            await SendEvent(import, cancellationToken);
        }

        public async Task StartSaving(LeagueImport import, CancellationToken cancellationToken)
        {
            import.StatusId = LeagueImportStatusId.SavingData;
            import.Progress = 20;

            await SendEvent(import, cancellationToken);
        }

        public async Task Complete(LeagueImport import, int leagueId, CancellationToken cancellationToken)
        {
            import.StatusId = LeagueImportStatusId.Completed;
            import.Progress = 100;
            import.LeagueId = leagueId;

            await SendEvent(import, cancellationToken);
        }

        public async Task Error(LeagueImport import, CancellationToken cancellationToken)
        {
            import.StatusId = LeagueImportStatusId.Failed;
            import.Progress = 100;
            import.Error = "An unexpected error occurred while importing your league's data. Please try again later.";

            await SendEvent(import, cancellationToken);
        }
    }
}
