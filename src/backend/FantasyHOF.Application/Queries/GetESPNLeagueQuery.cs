using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types.Inputs;
using FantasyHOF.ESPN.Types.Outputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries
{
    public sealed record GetESPNLeagueQuery(ESPNLeagueCredentials Credentials) : IRequest<List<ESPNWeeklyLeagueData>>
    {
        public sealed class GetESPNLeagueQueryHandler : IRequestHandler<GetESPNLeagueQuery, List<ESPNWeeklyLeagueData>>
        {
            private IESPNAPIClientBuilder _espnClientBuilder;
            private IESPNLeagueMapper _espnMapper;

            public GetESPNLeagueQueryHandler(IESPNAPIClientBuilder espnClientBuilder, IESPNLeagueMapper espnMapper)
            {
                _espnClientBuilder = espnClientBuilder;
                _espnMapper = espnMapper;
            }

            public async Task<List<ESPNWeeklyLeagueData>> Handle(GetESPNLeagueQuery request, CancellationToken cancellationToken)
            {
                ESPNAPIClient espnClient = _espnClientBuilder.Build(request.Credentials);

                List<ESPNSeasonalLeagueData> memberDetails = await espnClient.LoadSeasonalLeagueData();
                List<ESPNWeeklyLeagueData> matchupDetails = await espnClient.LoadWeeklyLeagueData();

                return matchupDetails;
                //return _espnMapper.MapLeague(memberDetails, matchupDetails);
            }
        }
    }
}
