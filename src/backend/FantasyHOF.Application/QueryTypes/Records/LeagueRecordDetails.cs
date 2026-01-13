using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record LeagueRecordDetails(int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:m:{MemberDetails.MemberId}";
    }
}
