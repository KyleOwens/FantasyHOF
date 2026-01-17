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
        Task ExecuteAsync(int pendingLeagueId, ESPNLeagueCredentials credentials, IJobCancellationToken ct);
    }

    public class LeagueImportJob(
        FantasyHOFDBContext database,
        IMediator mediator,
        ILeagueImportEventSender eventSender
    ) : ILeagueImportJob
    {
        [JobDisplayName("Import ESPN League {1}")]
        public async Task ExecuteAsync(int pendingLeagueId, ESPNLeagueCredentials credentials, IJobCancellationToken jobToken)
        {
            CancellationToken ct = jobToken.ShutdownToken;

            LeagueImport? import = await database.LeagueImports
                .Include(x => x.User)
                    .ThenInclude(x => x.Leagues)
                .SingleAsync(x => x.Id == pendingLeagueId, ct);

            try
            {
                await eventSender.StartImport(import, ct);
                League newLeague = await mediator.Send(new GetESPNLeagueQuery(credentials, import), ct);

                await eventSender.StartSaving(import, ct);
                import.User.RemoveLeagueIfExists(FantasyProviderId.ESPN, credentials.LeagueId);
                import.User.AddLeague(newLeague);
                await database.SaveChangesAsync(ct);

                await eventSender.Complete(import, newLeague.Id, ct);
            }
            catch
            {
                await eventSender.Error(import, ct);
            }
        }
    }
}
