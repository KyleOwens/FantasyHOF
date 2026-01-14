using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public abstract record RecordDetails(int Rank, RecordMetric Metric, LeagueMember MemberDetails)
    {
        public abstract string Key { get; }
    }
}
