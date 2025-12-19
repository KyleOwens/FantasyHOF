using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.Queries.LeagueSeasons
{
    public record GetLeagueSeasonByIdQuery(int LeagueSeasonId) : IRequest<LeagueSeason?>
    {
        public class GetLeagueSeasonByIdQueryHandler(IMediator mediator) 
            : IRequestHandler<GetLeagueSeasonByIdQuery, LeagueSeason?>
        {
            private readonly IMediator _mediator = mediator;

            public async Task<LeagueSeason?> Handle(GetLeagueSeasonByIdQuery request, CancellationToken cancellationToken)
            {
                return (await _mediator.Send(new GetLeagueSeasonsByIdsQuery([request.LeagueSeasonId]), cancellationToken))
                    .FirstOrDefault();
            }
        }
    }
}
