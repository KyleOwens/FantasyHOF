using FantasyHOF.Application.Mappers;
using FantasyHOF.Domain.Types;
using FantasyHOF.ESPN;
using FantasyHOF.ESPN.Types;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries
{
    public sealed record GetESPNLeagueQuery(ESPNLeagueCredentials Credentials) : IRequest<FantasyLeague>
    {
        public sealed class GetESPNLeagueQueryHandler : IRequestHandler<GetESPNLeagueQuery, FantasyLeague>
        {
            private IESPNHTTPService _espnClient;
            private IESPNLeagueMapper _espnMapper;

            public GetESPNLeagueQueryHandler(IESPNHTTPService espnClient, IESPNLeagueMapper espnMapper)
            {
                _espnClient = espnClient;
                _espnMapper = espnMapper;
            }

            public async Task<FantasyLeague> Handle(GetESPNLeagueQuery request, CancellationToken cancellationToken)
            {
                List<ESPNLeagueYearMemberDetails> leagueYears = await _espnClient.LoadAllMemberData(request.Credentials);

                return _espnMapper.MapLeague(leagueYears);
            }
        }
    }
}
