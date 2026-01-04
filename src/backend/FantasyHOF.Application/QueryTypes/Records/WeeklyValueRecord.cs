using FantasyHOF.Application.Enums;
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

        public WeeklyValueRecord(FantasyMember member, RecordType type, int year, int week, decimal value)
            : base(member, type, year, week)
        {
            Value = value;
        }
    }
}
