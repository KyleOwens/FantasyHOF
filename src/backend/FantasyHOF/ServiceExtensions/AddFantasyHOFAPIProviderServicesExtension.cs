using FantasyHOF.Application.Mappers;
using FantasyHOF.ESPN;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFAPIProviderServicesExtension
    {
        public static IServiceCollection AddFantasyHOFAPIProviderServices(this IServiceCollection services)
        {
            services.AddTransient<IESPNAPIClientBuilder, ESPNAPIClientBuilder>();
            services.AddSingleton<IESPNLeagueMapper, ESPNLeagueMapper>();
            
            return services;
        }
    }
}
