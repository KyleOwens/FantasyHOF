using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record SeasonalRecordEntry(int Year, int Rank, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordEntry(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:m:{MemberDetails.MemberId}";
    }
}
