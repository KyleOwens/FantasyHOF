using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record LeagueRecordEntry(int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordEntry(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:m:{MemberDetails.MemberId}";
    }
}
