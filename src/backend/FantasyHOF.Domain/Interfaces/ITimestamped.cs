namespace FantasyHOF.Domain.Interfaces
{
    public interface ITimestamped
    {
        public DateTimeOffset CreatedAt { get; }
        public DateTimeOffset UpdatedAt { get; }
    }
}
