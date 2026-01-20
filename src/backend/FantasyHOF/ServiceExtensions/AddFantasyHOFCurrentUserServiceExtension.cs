using FantasyHOF.Application.Services.Authentication;
using FantasyHOF.Infrastructure.ServiceDefinitions;

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
