using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record WeeklyRecordDetails(int Year, int Week, int Rank, RecordType RecordType, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, RecordType, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:m:{MemberDetails.MemberId}";
    }
}
