using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public class LeagueRecord : Record
    {
        public LeagueRecord(FantasyMember member, RecordTypeId type, RecordMetric metric) 
            : base(member, type, metric) { }
    }
}
