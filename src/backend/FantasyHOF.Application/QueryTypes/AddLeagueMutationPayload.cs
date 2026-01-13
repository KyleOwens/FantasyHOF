using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes
{
    public sealed record AddLeagueMutationPayload(int PendingLeagueId, string jobId);
}
