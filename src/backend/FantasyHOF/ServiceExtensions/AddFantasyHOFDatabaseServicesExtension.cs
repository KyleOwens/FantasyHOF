using FantasyHOF.EntityFramework;
using FantasyHOF.Infrastructure.ServiceDefinitions;
using Microsoft.EntityFrameworkCore;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFDatabaseServicesExtension
    {
        public static IServiceCollection AddFantasyHOFDatabaseServices(this IServiceCollection services, string appConnectionString)
        {
            services.AddDbContext<FantasyHOFDBContext>((serviceProvider, options) =>
            {
                options.UseNpgsql(appConnectionString)
                    .UseSnakeCaseNamingConvention();

                ICurrentUserService currentUserService = serviceProvider.GetRequiredService<ICurrentUserService>();
                options.AddInterceptors(new RLSConnectionInterceptor(currentUserService));
            });

            return services;
        }
    }
}
