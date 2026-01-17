using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class WeeklyRecord(FantasyMember member, RecordTypeId type, int year, int week, RecordMetric metric)
        : SeasonalRecord(member, type, year, metric)
    {
        public int Week { get; init; } = week;
    }
}
