using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.QueryTypes.Records
{
    public sealed record SeasonalRecordDetails(int Year, int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:m:{MemberDetails.MemberId}";
    }
}
