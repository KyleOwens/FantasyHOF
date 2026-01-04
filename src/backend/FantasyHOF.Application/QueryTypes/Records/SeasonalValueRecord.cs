using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyHOF.Domain.Enums;

namespace FantasyHOF.Domain.Types.Records
{
    public class SeasonalValueRecord : SeasonalRecord, IValueRecord
    {
        public decimal Value { get; init; }

        public SeasonalValueRecord(FantasyMember member, int year, decimal value)
            : base(member, year)
        {
            Year = year;
            Value = value;
        }
    }
}
