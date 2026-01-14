using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class LeagueRecord : Record
    {
        public LeagueRecord(FantasyMember member, RecordTypeId type, RecordMetric metric)
            : base(member, type, metric) { }
    }
}
