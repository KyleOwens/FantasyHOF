using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class LeagueRecord(FantasyMember member, RecordTypeId type, RecordMetric metric)
        : Record(member, type, metric);
}
