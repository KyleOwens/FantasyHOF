using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public class WeeklyRecord : SeasonalRecord
    {
        public int Week { get; init; }

        public WeeklyRecord(FantasyMember member, RecordTypeId type, int year, int week, RecordMetric metric) 
            : base(member, type, year, metric)
        {
            Week = week;
        }
    }
}
