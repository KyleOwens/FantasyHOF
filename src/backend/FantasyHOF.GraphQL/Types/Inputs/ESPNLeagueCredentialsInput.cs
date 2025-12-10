using FantasyHOF.ESPN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.GraphQL.Types.Inputs
{
    public sealed record ESPNLeagueCredentialsInput(string LeagueId, string SWID, string ESPNS2Id) { }
}
