using FantasyHOF.Application.Queries.ESPNQueries;
using FantasyHOF.Application.Services;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN.Types.Inputs;
using Hangfire;
using HotChocolate.Subscriptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FantasyHOF.Application.BackgroundJobs
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
                League newLeague = await mediator.Send(new GetESPNLeagueQuery(credentials), cancellationToken);

                await eventSender.StartSaving(import, cancellationToken);
                import.User.RemoveLeagueIfExists(FantasyProviderId.ESPN, credentials.LeagueId);
                import.User.AddLeague(newLeague);
                await database.SaveChangesAsync(cancellationToken);

                await eventSender.Complete(import, cancellationToken);
            }
            catch(Exception exception)
            {
                await eventSender.Error(import, cancellationToken);

                throw;
            }
        }
    }
}
