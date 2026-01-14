using FantasyHOF.Domain.Entities;

namespace FantasyHOF.Application.Types.Queries.Records
{
    public sealed record PlayerRecordDetails(int Year, int Week, int Rank, Player player, RecordMetric Metric, LeagueMember MemberDetails)
        : RecordDetails(Rank, Metric, MemberDetails)
    {
        public override string Key => $"l:{MemberDetails.LeagueId}:y:{Year}:w{Week}:p:{player.Id}:m:{MemberDetails.MemberId}";
    }
}
