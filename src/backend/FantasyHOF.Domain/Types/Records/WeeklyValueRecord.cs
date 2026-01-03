using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class WeeklyValueRecord : WeeklyRecord, IValueRecord
    {
        public decimal Value { get; init; }

        protected WeeklyValueRecord() { }

        public WeeklyValueRecord(FantasyMember member, int year, int week, decimal value)
        {
            Year = year;
            Week = week;
            Value = value;

            SetMember(member);
        }
    }
}
