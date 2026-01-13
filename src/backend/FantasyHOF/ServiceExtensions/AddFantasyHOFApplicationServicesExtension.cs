using FantasyHOF.Application.BackgroundJobs;
using FantasyHOF.Application.Configuration;
using FantasyHOF.Application.Mappers;
using FantasyHOF.Application.Registries;
using FantasyHOF.Application.Services;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.ESPN;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFApplicationServicesExtension
    {
        public static IServiceCollection AddFantasyHOFApplicationServices(this IServiceCollection services, IConfigurationSection appConfigSection)
        {
            services.AddTransient<IESPNAPIClientBuilder, ESPNAPIClientBuilder>();
            services.AddSingleton<IESPNLeagueMapper, ESPNLeagueMapper>();

            services.AddScoped<ILeagueImportJob, LeagueImportJob>();
            services.AddScoped<ILeagueImportEventSender, LeagueImportEventSender>();

            services.Configure<AppConfig>(appConfigSection);

            MetricSelectorRegistry<LeagueMemberAggregatedStats>.Selectors = LeagueMetricSelectorRegistry.Selectors;

            MetricSelectorRegistry<LeagueSeasonMemberAggregatedStats>.Selectors = SeasonalMetricSelectorRegistry.Selectors;

            MetricSelectorRegistry<WeeklyAggregationData>.Selectors = WeeklyMetricSelectorRegistry.Selectors;
            MetricSelectorRegistry<WeeklyAggregationData>.Filters = WeeklyMetricSelectorRegistry.Filters;

            MetricSelectorRegistry<PlayerAggregationData>.Selectors = PlayerMetricSelectorRegistry.Selectors;
            MetricSelectorRegistry<PlayerAggregationData>.Filters = PlayerMetricSelectorRegistry.Filters;

            return services;
        }
    }
}
