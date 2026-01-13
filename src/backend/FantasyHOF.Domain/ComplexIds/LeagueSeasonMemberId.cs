namespace FantasyHOF.Domain.ComplexIds
{
    public readonly record struct LeagueSeasonMemberId(int LeagueSeasonId, int MemberId)
    {
        public override string ToString() => $"{LeagueSeasonId}:{MemberId}";

        public static LeagueSeasonMemberId Parse(string value)
        {
            string[] parts = value.Split(':');

            return new LeagueSeasonMemberId(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}
