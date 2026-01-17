using FantasyHOF.Application.Queries.ESPNQueries;
using FantasyHOF.Application.Services.Events;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN.Types.Inputs;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Services.BackgroundJobs
{
    public interface ILeagueImportJob
    {
        Task ExecuteAsync(int pendingLeagueId, ESPNLeagueCredentials credentials, IJobCancellationToken cancellationToken);
    }

    public class LeagueImportJob(
        FantasyHOFDBContext database,
        IMediator mediator,
        ILeagueImportEventSender eventSender) : ILeagueImportJob
    {
        [JobDisplayName("Import ESPN League {1}")]
        public async Task ExecuteAsync(int pendingLeagueId, ESPNLeagueCredentials credentials, IJobCancellationToken jobToken)
        {
            CancellationToken cancellationToken = jobToken.ShutdownToken;

            LeagueImport? import = await database.LeagueImports
                .Include(x => x.User)
                    .ThenInclude(x => x.Leagues)
                .SingleAsync(x => x.Id == pendingLeagueId, cancellationToken);

            try
            {
                await eventSender.StartImport(import, cancellationToken);
                League newLeague = await mediator.Send(new GetESPNLeagueQuery(credentials, import), cancellationToken);

                await eventSender.StartSaving(import, cancellationToken);
                import.User.RemoveLeagueIfExists(FantasyProviderId.ESPN, credentials.LeagueId);
                import.User.AddLeague(newLeague);
                await database.SaveChangesAsync(cancellationToken);

                await eventSender.Complete(import, newLeague.Id, cancellationToken);
            }
            catch
            {
                await eventSender.Error(import, cancellationToken);
            }
        }
    }
}
