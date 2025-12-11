namespace FantasyHOF.Domain.Types
{
    public class FantasyPlayer
    {
        public required int PlayerId { get; init; }
        public required string FirstName { get; init; }
        public required string FullName { get; init; }
    }
}