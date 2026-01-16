using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record WeeklyRecordEntry(int Year, int Week, int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordEntry(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:m:{MemberDetails.MemberId}";
    }
}
