using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class SeasonalRecord(FantasyMember member, RecordTypeId type, int year, RecordMetric metric)
        : LeagueRecord(member, type, metric)
    {
        public int Year { get; init; } = year;
    }
}
