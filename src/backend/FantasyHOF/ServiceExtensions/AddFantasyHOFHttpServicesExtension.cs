namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFHttpServicesExtension
    {
        public static IServiceCollection AddFantasyHOFHttpServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddHttpClient();

            return services;
        }
    }
}
