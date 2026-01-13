using FantasyHOF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public abstract record RecordDetails(int Rank, RecordMetric Metric, LeagueMember MemberDetails)
    {
        public abstract string Key { get; }
    }
}
