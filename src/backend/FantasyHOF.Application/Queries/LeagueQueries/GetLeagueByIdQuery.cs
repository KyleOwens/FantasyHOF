using FantasyHOF.EntityFramework;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Queries.LeagueQueries
{
    public sealed record GetLeagueByIdQuery(int leagueId) : IRequest<League?>;

    public sealed class GetLeagueByIdQueryHandler : IRequestHandler<GetLeagueByIdQuery, League?>
    {
        private readonly IMediator _mediator;

        public GetLeagueByIdQueryHandler(IMediator mediator) => _mediator = mediator;

        public async Task<League?> Handle(GetLeagueByIdQuery request, CancellationToken cancellationToken)
        {
            return (await _mediator.Send(new GetLeaguesByIdsQuery([request.leagueId]), cancellationToken))
                .FirstOrDefault();    
        }
    }
}
