using FantasyHOF.EntityFramework;
using Hangfire;
using Hangfire.PostgreSql;
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

            services.AddHangfire(config => config
               .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
               .UseSimpleAssemblyNameTypeSerializer()
               .UseRecommendedSerializerSettings()
               .UsePostgreSqlStorage(x => x.UseNpgsqlConnection(connectionString)));

            services.AddHangfireServer();
               
            return services;
        }
    }
}
