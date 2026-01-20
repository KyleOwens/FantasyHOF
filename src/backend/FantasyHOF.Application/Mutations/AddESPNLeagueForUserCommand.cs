using FantasyHOF.Application.Services.BackgroundJobs;
using FantasyHOF.Application.Types.Exceptions;
using FantasyHOF.Application.Types.Mutations;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.Application.Mutations
{
    public sealed record AddESPNLeagueForUserCommand(ESPNLeagueCredentials LeagueCredentials)
        : IRequest<AddLeagueMutationPayload>
    {
        public sealed class AddESPNLeagueForUserCommandHandler(
            FantasyHOFDBContext database,
            ICurrentUserService currentUser,
            IBackgroundJobClient jobClient,
            IESPNAPIClientBuilder espnClientBuilder
        ) : IRequestHandler<AddESPNLeagueForUserCommand, AddLeagueMutationPayload>
        {
            public async Task<AddLeagueMutationPayload> Handle(AddESPNLeagueForUserCommand request, CancellationToken ct)
            {
                User user = await database.Users
                    .Include(user => user.Leagues)
                    .SingleAsync(user => user.Id == currentUser.Id, ct);

                ESPNAPIClient client = espnClientBuilder.Build(request.LeagueCredentials);
                await client.ValidateCredentialsAsync();

                List<LeagueImport> existingImports = await database.LeagueImports
                    .Where(import => import.UserId == currentUser.Id)
                    .Where(import => import.ProviderleagueId == request.LeagueCredentials.LeagueId)
                    .Where(import => import.StatusId != LeagueImportStatusId.Failed && import.StatusId != LeagueImportStatusId.Completed)
                    .ToListAsync(ct);

                if (existingImports.Count != 0) throw new LeagueImportExistsException();

                LeagueImport importTracker = new()
                {
                    Progress = 0,
                    ProviderId = FantasyProviderId.ESPN,
                    ProviderleagueId = request.LeagueCredentials.LeagueId,
                    StatusId = LeagueImportStatusId.Queued,
                    UserId = user.Id
                };

                database.LeagueImports.Add(importTracker);
                await database.SaveChangesAsync(ct);

                string jobId = jobClient.Enqueue<ILeagueImportJob>(
                    job => job.ExecuteAsync(importTracker.Id, currentUser.Id, request.LeagueCredentials, JobCancellationToken.Null));

                return new(jobId, importTracker);
            }
        }
    }
}
