namespace FantasyHOF.Infrastructure.ServiceDefinitions
{
    public interface ICurrentUserService
    {
        bool IsAuthenticated { get; }
        bool IsAdmin { get; }
        string Id { get; }
    }
}
