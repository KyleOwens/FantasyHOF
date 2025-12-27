using FantasyHOF.Application.Queries.ESPNQueries;
using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using FantasyHOF.ESPN.Types.Inputs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Mutations
{
    public sealed record AddDemoESPNLeagueCommand(ESPNLeagueCredentials Credentials) : IRequest<League>
    {
        public sealed class AddDemoESPNLeagueCommandHandler(IMediator mediator, FantasyHOFDBContext database)
            : IRequestHandler<AddDemoESPNLeagueCommand, League>
        {
            public async Task<League> Handle(AddDemoESPNLeagueCommand request, CancellationToken cancellationToken)
            {
                League league = await mediator.Send(new GetESPNLeagueQuery(request.Credentials), cancellationToken);

                database.Leagues.Add(league);

                try
                {
                    await database.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    throw new Exception(e.InnerException?.Message);
                }
                

                return league;
            }
        }
    }
}
