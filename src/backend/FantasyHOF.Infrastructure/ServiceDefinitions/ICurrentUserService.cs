namespace FantasyHOF.Infrastructure.ServiceDefinitions
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        string ClerkUserId { get; }
        Task<Guid> GetUserIdAsync(CancellationToken ct = default);
        Task<Guid?> TryGetUserIdAsync(CancellationToken ct = default);
    }
}
