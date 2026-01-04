using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public abstract class WeeklyRecord : SeasonalRecord
    {
        public int Week { get; init; }

        public WeeklyRecord(FantasyMember member, RecordType type, int year, int week) 
            : base(member, type, year)
        {
            Week = week;
        }
    }
}
