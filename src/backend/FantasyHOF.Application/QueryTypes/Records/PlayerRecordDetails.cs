using FantasyHOF.Domain.Entities;
using FantasyHOF.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record PlayerRecordDetails(int Year, int Week, int Rank, Player player, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:p:{player.Id}:m:{MemberDetails.MemberId}";
}
}
