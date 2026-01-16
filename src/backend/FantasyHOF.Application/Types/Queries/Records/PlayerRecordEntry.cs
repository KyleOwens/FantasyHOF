using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record PlayerRecordEntry(int Year, int Week, int Rank, Player Player, Position position, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordEntry(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:p:{Player.Id}:m:{MemberDetails.MemberId}";
    }
}
