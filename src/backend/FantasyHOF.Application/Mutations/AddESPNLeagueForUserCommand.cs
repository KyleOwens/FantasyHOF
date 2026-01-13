using FantasyHOF.Application.BackgroundJobs;
using FantasyHOF.Application.Mappers;
using FantasyHOF.Application.Queries.ESPNQueries;
using FantasyHOF.Application.QueryTypes;
using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Enums;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.Infrastructure.Authentication;
using Hangfire;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mutations
{
    public sealed record AddESPNLeagueForUserCommand(ESPNLeagueCredentials LeagueCredentials) : IRequest<AddLeagueMutationPayload>
    {
        public sealed class AddESPNLeagueForUserCommandHandler(ICurrentUserService currentUser, FantasyHOFDBContext database, IBackgroundJobClient jobClient, IESPNAPIClientBuilder espnClientBuilder) : IRequestHandler<AddESPNLeagueForUserCommand, AddLeagueMutationPayload>
        {
            public async Task<AddLeagueMutationPayload> Handle(AddESPNLeagueForUserCommand request, CancellationToken cancellationToken)
            {
                Guid authenticatedUserId = await currentUser.GetUserIdAsync(cancellationToken);
                User user = await database.Users
                    .Include(user => user.Leagues)
                    .SingleAsync(user => user.Id == authenticatedUserId, cancellationToken);

                ESPNAPIClient client = espnClientBuilder.Build(request.LeagueCredentials);
                await client.ValidateCredentialsAsync();

                LeagueImport importTracker = new()
                {
                    Progress = 0,
                    ProviderId = FantasyProviderId.ESPN,
                    ProviderleagueId = request.LeagueCredentials.LeagueId,
                    StatusId = LeagueImportStatusId.Queued,
                    UserId = user.Id
                };

                database.LeagueImports.Add(importTracker);
                await database.SaveChangesAsync();

                string jobId = jobClient.Enqueue<ILeagueImportJob>(job => job.ExecuteAsync(importTracker.Id, request.LeagueCredentials, JobCancellationToken.Null));

                return new(importTracker.Id, jobId);
            }
        }
    }
}
