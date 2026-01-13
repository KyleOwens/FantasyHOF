using FantasyHOF.Application.Authentication;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFCurrentUserServiceExtension
    {
        public static IServiceCollection AddFantasyHOFCurrentUserService(this IServiceCollection services)
        {
            return services.AddScoped<ICurrentUserService, CurrentUserService>();
        }
    }
}
