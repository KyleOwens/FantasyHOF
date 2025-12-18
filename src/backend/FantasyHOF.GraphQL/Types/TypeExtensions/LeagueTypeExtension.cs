using FantasyHOF.Domain.Types;
using FantasyHOF.EntityFramework;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.TypeExtensions
{
    [ExtendObjectType(typeof(League))]
    public class LeagueTypeExtension
    {
        //public IEnumerable<LeagueSeason> GetSeasons([Parent] League league, IMediator mediator)
        //{
        //    return ;
        //}
    }
}
