using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.QueryTypes.Records
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
