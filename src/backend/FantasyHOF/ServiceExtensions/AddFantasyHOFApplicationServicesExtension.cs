using FantasyHOF.Application.Services.BackgroundJobs;
using FantasyHOF.Application.Services.Builders;
using FantasyHOF.Application.Services.Events;
using FantasyHOF.Application.Services.Mappers;
using FantasyHOF.Application.Services.Registries;
using FantasyHOF.Application.Types.Configuration;
using FantasyHOF.Domain.Entities.Views;
using FantasyHOF.ESPN;
using Hangfire;
using Hangfire.PostgreSql;

namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFApplicationServicesExtension
    {
        public static IServiceCollection AddFantasyHOFApplicationServices(this IServiceCollection services, IConfigurationSection appConfigSection, string connectionString)
        {
            services.AddTransient<IESPNAPIClientBuilder, ESPNAPIClientBuilder>();
            services.AddSingleton<IESPNLeagueMapper, ESPNLeagueMapper>();
            services.AddScoped<IESPNLeagueBuilder, ESPNLeagueBuilder>();

            services.AddScoped<ILeagueImportJob, LeagueImportJob>();
            services.AddScoped<ILeagueImportEventSender, LeagueImportEventSender>();

            services.Configure<AppConfig>(appConfigSection);

            MetricSelectorRegistry<LeagueMemberAggregatedStats>.Selectors = LeagueMetricSelectorRegistry.Selectors;

            MetricSelectorRegistry<LeagueSeasonMemberAggregatedStats>.Selectors = SeasonalMetricSelectorRegistry.Selectors;

            MetricSelectorRegistry<WeeklyAggregationData>.Selectors = WeeklyMetricSelectorRegistry.Selectors;
            MetricSelectorRegistry<WeeklyAggregationData>.Filters = WeeklyMetricSelectorRegistry.Filters;

            MetricSelectorRegistry<PlayerAggregationData>.Selectors = PlayerMetricSelectorRegistry.Selectors;
            MetricSelectorRegistry<PlayerAggregationData>.Filters = PlayerMetricSelectorRegistry.Filters;

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
