using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace FantasyHOF.EntityFramework
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FantasyHOFDBContext>
    {
        public FantasyHOFDBContext CreateDbContext(string[] args)
        {
            // Allows us to get configuration settings from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddJsonFile("appsettings.Development.json", optional: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<FantasyHOFDBContext>();

            optionsBuilder.UseNpgsql(configuration.GetConnectionString("AdminConnection"))
                .UseSnakeCaseNamingConvention();

            return new FantasyHOFDBContext(optionsBuilder.Options);
        }
    }
}
