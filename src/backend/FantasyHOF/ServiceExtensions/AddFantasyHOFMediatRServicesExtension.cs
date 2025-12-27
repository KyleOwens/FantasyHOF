namespace FantasyHOF.ServiceExtensions
{
    public static class AddFantasyHOFMediatRServicesExtension
    {
        public static IServiceCollection AddFantasyHOFMediatRServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(Application.AssemblyMarker).Assembly);
            });

            return services;
        }
    }
}
