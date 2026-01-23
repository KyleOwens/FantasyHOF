using FantasyHOF.ApplicationBuilderExtensions;
using FantasyHOF.EntityFramework;
using FantasyHOF.ServiceExtensions;
using FantasyHOF.WebApplicationExtensions;
using Hangfire;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.SingleLine = true;
    options.TimestampFormat = "HH:mm:ss";
});

builder.Logging.SetMinimumLevel(LogLevel.Information);

string adminConnectionString = builder.Configuration.GetConnectionString("AdminConnection")
    ?? throw new Exception("Failed to load the admin connection string from config");

string appConnectionString = builder.Configuration.GetConnectionString("AppConnection")
    ?? throw new Exception("Failed to load the app connection string from config");

builder.Services.AddFantasyHOFAuthenticationServices(
    builder.Environment,
    builder.Configuration["Authentication:Authority"]
    ?? throw new Exception("Failed to load JWT authority from config"));

builder.Services.AddFantasyHOFDatabaseServices(appConnectionString);

builder.Services.AddFantasyHOFHttpServices();
builder.Services.AddFantasyHOFCurrentUserService();
builder.Services.AddFantasyHOFApplicationServices(builder.Configuration.GetSection("Authentication"), appConnectionString);
builder.Services.AddFantasyHOFMediatRServices();

await builder.AddFantasyHOFGraphQL();

var app = builder.Build();

var optionsBuilder = new DbContextOptionsBuilder<FantasyHOFDBContext>();
optionsBuilder.UseNpgsql(adminConnectionString)
    .UseSnakeCaseNamingConvention();

using var migrationContext = new FantasyHOFDBContext(optionsBuilder.Options);
migrationContext.Database.Migrate();

await app.AddGraphQLDeveloperToolsAsync();

if (app.Environment.IsDevelopment())
{
    app.UseHangfireDashboard("/hangfire");
}

app.UseAuthentication();
app.UseAuthorization();

app.UseDefaultFiles();
app.UseStaticFiles();
app.MapFallbackToFile("index.html");

app.MapGraphQL();

app.RunWithGraphQLCommands(args);





