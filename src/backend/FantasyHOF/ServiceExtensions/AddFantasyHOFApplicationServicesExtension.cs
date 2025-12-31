using FantasyHOF.Application.Configuration;
using FantasyHOF.Application.Mappers;
using FantasyHOF.ESPN;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFApplicationServicesExtension
    {
        public static IServiceCollection AddFantasyHOFApplicationServices(this IServiceCollection services, IConfigurationSection appConfigSection)
        {
            services.AddTransient<IESPNAPIClientBuilder, ESPNAPIClientBuilder>();
            services.AddSingleton<IESPNLeagueMapper, ESPNLeagueMapper>();

            services.AddSingleton<IRecordCalculator, RecordCalculator>();

            services.Configure<AppConfig>(appConfigSection);

            return services;
        }
    }
}
