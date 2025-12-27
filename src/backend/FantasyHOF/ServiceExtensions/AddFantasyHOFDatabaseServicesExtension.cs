using FantasyHOF.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFDatabaseServicesExtension
    {
        public static IServiceCollection AddFantasyHOFDatabaseServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FantasyHOFDBContext>(options =>
            {
                options.UseNpgsql(connectionString)
                    .UseSnakeCaseNamingConvention();

                options.EnableSensitiveDataLogging();
            });

            return services;
        }
    }
}
