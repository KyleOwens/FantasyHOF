using FantasyHOF.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyHOF.Domain.Types.Records
{
    public class SeasonalRecord : LeagueRecord
    {
        public int Year { get; init; }

        public SeasonalRecord(FantasyMember member, RecordType type, int year, decimal value)
            : base(member, type, value) 
        {
            Year = year;        
        }
    }
}
