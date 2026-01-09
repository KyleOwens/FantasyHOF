using FantasyHOF.Application.Enums;
using FantasyHOF.Application.QueryTypes.Records;
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

        public SeasonalRecord(FantasyMember member, RecordTypeId type, int year, RecordMetric metric)
            : base(member, type, metric) 
        {
            Year = year;        
        }
    }
}
