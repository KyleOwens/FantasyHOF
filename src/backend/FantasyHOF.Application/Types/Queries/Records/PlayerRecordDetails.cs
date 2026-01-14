using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record PlayerRecordDetails(int Year, int Week, int Rank, RecordType RecordType, Player Player, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, RecordType, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:p:{Player.Id}:m:{MemberDetails.MemberId}";
    }
}
