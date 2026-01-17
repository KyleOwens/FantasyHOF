using FantasyHOF.Application.Enums;
using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public class PlayerRecord(FantasyMember member, RecordTypeId type, Player player, int year, int week, RecordMetric metric)
        : WeeklyRecord(member, type, year, week, metric)
    {
        public Player Player { get; private set; } = player;
    }
}
