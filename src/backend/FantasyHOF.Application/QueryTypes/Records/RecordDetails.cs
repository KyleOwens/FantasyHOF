using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public abstract record RecordDetails(int Rank, RecordMetric Metric, LeagueMember MemberDetails)
    {
        public abstract string Key { get; }
    }
}
