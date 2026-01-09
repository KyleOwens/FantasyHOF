using FantasyHOF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record LeagueRecordDetails(int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:m:{MemberDetails.MemberId}";
    }
}
