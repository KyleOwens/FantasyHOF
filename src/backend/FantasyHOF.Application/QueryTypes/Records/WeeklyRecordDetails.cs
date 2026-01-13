using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record WeeklyRecordDetails(int Year, int Week, int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:m:{MemberDetails.MemberId}";
    }
}
