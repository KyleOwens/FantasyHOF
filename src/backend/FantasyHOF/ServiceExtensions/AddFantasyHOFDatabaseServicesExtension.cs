using FantasyHOF.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFDatabaseServicesExtension
    {
        public static IServiceCollection AddFantasyHOFDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<FantasyHOFDBContext>(
                options =>
                {
                    options.UseNpgsql(connectionString)
                        .UseSnakeCaseNamingConvention();
                });

            return services;
        }
    }
}
