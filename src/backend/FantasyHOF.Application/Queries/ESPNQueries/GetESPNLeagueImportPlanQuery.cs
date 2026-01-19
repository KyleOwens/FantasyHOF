using FantasyHOF.Application.Services.Events;
using FantasyHOF.Application.Services.ImportPlanBuilders;
using FantasyHOF.Application.Types.Services;
using FantasyHOF.Domain.Entities;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Outputs;
using MediatR;

namespace FantasyHOF.Application.Queries.ESPNQueries
{
    public sealed record GetESPNLeagueImportPlanQuery(Guid UserId, ESPNLeagueCredentials Credentials, LeagueImport Import)
        : IRequest<LeagueImportPlan>
    {
        public sealed class GetESPNLeagueImportPlanQueryHandler(
            IESPNAPIClientBuilder espnClientBuilder,
            IESPNImportPlanBuilder leagueBuilder,
            ILeagueImportEventSender eventSender
        ) : IRequestHandler<GetESPNLeagueImportPlanQuery, LeagueImportPlan>
        {
            public async Task<LeagueImportPlan> Handle(GetESPNLeagueImportPlanQuery request, CancellationToken ct)
            {
                ESPNAPIClient espnClient = espnClientBuilder.Build(request.Credentials);

                await eventSender.StartLoadingData(request.Import, ct);

                IEnumerable<ESPNSeasonalLeagueData> espnSeasonalData = await espnClient.LoadSeasonalLeagueData();
                IEnumerable<ESPNWeeklyLeagueData> espnWeeklyData = await espnClient.LoadWeeklyLeagueData();

                return await leagueBuilder.BuildNewLeague(
                    request.Credentials.LeagueId,
                    request.UserId,
                    request.Import,
                    espnSeasonalData,
                    espnWeeklyData,
                    ct
                );
            }
        }
    }
}

