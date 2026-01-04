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

        public WeeklyRecord(FantasyMember member, int year, int week) : base(member, year)
        {
            Week = week;
        }
    }
}
