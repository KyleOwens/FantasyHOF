using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class SeasonalValueRecord : SeasonalRecord, IValueRecord
    {
        public decimal Value { get; init; }

        public SeasonalValueRecord(FantasyMember member, RecordType type, int year, decimal value)
            : base(member, type, year)
        {
            Year = year;
            Value = value;
        }
    }
}
