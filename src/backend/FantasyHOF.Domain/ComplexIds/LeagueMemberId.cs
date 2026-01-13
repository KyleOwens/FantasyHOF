namespace FantasyHOF.Domain.ComplexIds
{
    public readonly record struct LeagueMemberId(int LeagueId, int MemberId)
    {
        public override string ToString() => $"{LeagueId}:{MemberId}";

        public static LeagueMemberId Parse(string value)
        {
            string[] parts = value.Split(':');

            return new LeagueMemberId(int.Parse(parts[0]), int.Parse(parts[1]));
        }
    }
}
