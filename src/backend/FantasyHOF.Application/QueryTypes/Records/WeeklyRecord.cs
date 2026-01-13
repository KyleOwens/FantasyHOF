using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

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
